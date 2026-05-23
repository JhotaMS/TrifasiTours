<!-- Provide an overview of what your template package does and how to get started.
Consider previewing the README before uploading (https://learn.microsoft.com/en-us/nuget/nuget-org/package-readme-on-nuget-org#preview-your-readme). -->
# Plantilla Hexagonal Architecture
La arquitectura hexagonal, también conocida como "Arquitectura de Puerto y Adaptador", es un patrón de arquitectura de software que promueve una separación clara entre el núcleo de la aplicación (la lógica de negocio) y las partes externas (interfaces de usuario, bases de datos, servicios externos, etc.). Este patrón fue propuesto por Alistair Cockburn en 2005.

## Principios Clave de la Arquitectura Hexagonal

1. Separación de Responsabilidades: La arquitectura se divide en tres áreas principales: el núcleo de la aplicación, los puertos y los adaptadores.

2. Independencia del Núcleo: El núcleo de la aplicación (dominio) no debe depender de detalles externos. Debe estar aislado y ser independiente, con sus reglas de negocio y lógica encapsulada.

3. Interacción a través de Puertos: Los puertos son interfaces que definen cómo las partes externas pueden interactuar con el núcleo de la aplicación. Actúan como puntos de entrada y salida.

4. Adaptadores para Comunicación: Los adaptadores son implementaciones concretas de los puertos. Permiten que las diferentes tecnologías externas (bases de datos, APIs, interfaces de usuario) interactúen con el núcleo de la aplicación.

## Componentes de la Arquitectura Hexagonal
1. Núcleo de la Aplicación (Dominio):

> - Entidades: Objetos del dominio con identidad propia y ciclo de vida.
> - Agregados: Grupos de entidades relacionadas que se tratan como una sola unidad.
> - Servicios del Dominio: Lógica de negocio que no encaja bien en entidades o agregados.
> - Repositorios: Interfaces para acceder a los objetos del dominio.

2. Puertos:

> - Puertos de Entrada: Interfaces que definen los casos de uso del sistema (cómo puede ser usado).
> - Puertos de Salida: Interfaces que definen las operaciones necesarias en el dominio que dependen de servicios externos.

3. Adaptadores:
> - Adaptadores de Entrada: Implementaciones de puertos de entrada (como controladores web, interfaces de usuario).
> - Adaptadores de Salida: Implementaciones de puertos de salida (como repositorios de bases de datos, clientes de servicios externos).
## Ventajas de la Arquitectura Hexagonal
- Flexibilidad y Mantenibilidad: Facilita el cambio de tecnologías externas sin afectar el núcleo de la aplicación.

- Pruebas y Testeabilidad: El núcleo independiente permite pruebas unitarias y de integración más efectivas.

- Escalabilidad y Extensibilidad: Permite agregar nuevas funcionalidades y tecnologías sin reestructurar el sistema.

- Claridad y Separación de Preocupaciones: Promueve una arquitectura más limpia y entendible.