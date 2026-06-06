using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrifasiTours.Application.Messaging;
using TrifasiTours.Application.Exceptions;
using TrifasiTours.Domain.Ports;
using TrifasiTours.Domain.Tours;
using TrifasiTours.Domain.Users;
using TrifasiTours.Domain.Abstractions;

namespace TrifasiTours.Application.Features.Tours.Commands.CreateTour;

internal sealed class CreateTourCommandHandler : ICommandHandler<CreateTourCommand, CreateTourResponse>
{
    private readonly IUnitOfWork unitOfWork;

    public CreateTourCommandHandler(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    public async Task<Result<CreateTourResponse>> Handle(
        CreateTourCommand request,
        CancellationToken cancellationToken
    )
    {
        // Validaciones básicas
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(request.Name))
            errors.Add("El nombre es obligatorio.");

        if (!string.IsNullOrWhiteSpace(request.Name) && request.Name.Length > 100)
            errors.Add("El nombre no puede superar 100 caracteres.");

        if (string.IsNullOrWhiteSpace(request.TipoTour))
            errors.Add("El tipo de tour es obligatorio.");

        if (!string.IsNullOrWhiteSpace(request.TipoTour) && request.TipoTour.Length > 500)
            errors.Add("El tipo de tour no puede superar 500 caracteres.");

        if (string.IsNullOrWhiteSpace(request.Municipio))
            errors.Add("El municipio es obligatorio.");

        if (!string.IsNullOrWhiteSpace(request.Municipio) && request.Municipio.Length > 500)
            errors.Add("El municipio no puede superar 500 caracteres.");

        if (string.IsNullOrWhiteSpace(request.Dificultad))
            errors.Add("La dificultad es obligatoria.");

        if (request.ValorTour <= 0)
            errors.Add("El valor del tour debe ser mayor a 0.");

        if (request.GuiaAsignadoId == Guid.Empty)
            errors.Add("El guía asignado es obligatorio.");

        if (string.IsNullOrWhiteSpace(request.Requisitos))
            errors.Add("Los requisitos son obligatorios.");

        if (!string.IsNullOrWhiteSpace(request.Requisitos) && request.Requisitos.Length > 500)
            errors.Add("Los requisitos no pueden superar 500 caracteres.");

        if (errors.Any())
            throw new ValidationApplicationException(errors);

        // Duplicado por nombre
        bool exists = await unitOfWork.Repository<Tour>()
            .Exitst(t => t.Name == request.Name, cancellationToken);

        if (exists)
            throw new ValidationApplicationException(new[] { "El nombre ya existe en el sistema." });

        // Validar guía
        var guia = await unitOfWork.Repository<User>()
            .GetByAsync(u => u.Id == request.GuiaAsignadoId, cancellationToken: cancellationToken);

        if (guia == null || guia == default)
            throw new NotFoundApplicationException("El guía asignado no existe o no está disponible.");

        // Si la entidad User contiene property 'Enabled', comprobarlo (no forzamos cambios en User.cs)
        var enabledProp = guia.GetType().GetProperty("Enabled");
        if (enabledProp != null)
        {
            var enabledVal = enabledProp.GetValue(guia);
            if (enabledVal is bool enabledBool && !enabledBool)
            {
                throw new ValidationApplicationException(new[] { "El guía asignado no está activo." });
            }
        }

        // Crear entidad y persistir
        var tour = Tour.Create(
            request.Name.Trim(),
            request.TipoTour.Trim(),
            request.Municipio.Trim(),
            request.Dificultad.Trim(),
            request.ValorTour,
            request.GuiaAsignadoId,
            request.Requisitos.Trim()
        );

        await unitOfWork.Repository<Tour>().AddAsync(new[] { tour }, cancellationToken);
        await unitOfWork.SaveChangesAsync();

        return new CreateTourResponse(tour.Id);
    }
}
