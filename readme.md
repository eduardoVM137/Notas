# Notas

¡Bienvenido/a a **Notas**! Este proyecto, desarrollado en **ASP.NET** con el patrón **MVC**, ofrece un entorno sencillo y potente para la toma de notas, la organización de tareas y, potencialmente, el manejo de tickets por proyecto. Si buscas una herramienta ágil para llevar un registro de pendientes, ideas o incidencias, este repositorio puede servirte como inspiración o punto de partida.

## Tabla de contenidos
- [Descripción](#descripción)
- [Arquitectura del proyecto](#arquitectura-del-proyecto)
- [Características](#características)
- [Tecnologías utilizadas](#tecnologías-utilizadas)
- [Instalación y configuración](#instalación-y-configuración)
- [Uso](#uso)
- [Contribución](#contribución)
- [Licencia](#licencia)
- [Contacto](#contacto)

---

## Descripción
**Notas** es una aplicación que permite **crear, editar y organizar notas** de manera sencilla. El objetivo principal es proveer una interfaz ligera y fácil de entender para capturar y gestionar información rápidamente.  
No obstante, el sistema puede evolucionar para usarse como un **administrador de tickets** (similar a un sistema de soporte) donde cada nota represente un ticket asociado a un proyecto, con atributos como prioridad, fecha de vencimiento, categoría, etc.

Algunos escenarios de uso pueden ser:
- Hacer anotaciones rápidas de ideas o recordatorios.
- Organizar la información de un proyecto con tareas pendientes.
- Gestionar tickets o incidencias relacionados con diferentes proyectos.
- Apuntes de clase o listas de compras.
- Llevar un registro de categorías (por ejemplo, "Urgente", "Pendiente", "Bug", "Mejora").

---

## Arquitectura del proyecto
Este proyecto hace uso del **patrón MVC (Modelo - Vista - Controlador)** propio de ASP.NET. A grandes rasgos:

1. **Modelos (Models)**:  
   - Contienen la definición de las entidades y la lógica de negocio.  
   - Representan la estructura de los datos (por ejemplo, la clase `Nota`, que puede incluir atributos como `Titulo`, `Descripcion`, `Categoria`, `Proyecto`, `Prioridad`, `FechaVencimiento`, etc.).

2. **Vistas (Views)**:
   - Son las interfaces de usuario escritas en **Razor** o HTML con sintaxis de Razor.  
   - Muestran la información proveniente del controlador y permiten la interacción con el usuario.

3. **Controladores (Controllers)**:
   - Reciben las peticiones (requests) del usuario, procesan la lógica necesaria (usando los modelos) y devuelven las vistas apropiadas.


---

## Características

### Gestión de notas
- **Creación de notas**: Agrega notas de forma rápida a través de formularios sencillos.
- **Edición y eliminación**: Modifica o elimina notas existentes de manera intuitiva.
- **Organización por categorías**: Agrupa las notas según categorías personalizadas (por ejemplo, “Ideas”, “Reuniones”, “Aprendizaje”, etc.).

### Uso como sistema de soporte o tickets
- **Asignación de proyectos**: Cada nota/ticket puede asociarse a un proyecto específico para facilitar la clasificación y el seguimiento.
- **Gestión por estado**: (Pendiente, En progreso, Resuelto, etc.) - Ideal para manejar el estado de los tickets.
- **Prioridad y fechas de vencimiento**: Atributos como la prioridad (Alta, Media, Baja) y la fecha de vencimiento (deadline) para organizar de mejor forma las tareas más urgentes.
- **Filtros avanzados**: Filtra las notas/tickets por proyecto, estado, categoría o prioridad, brindando una vista personalizada de las tareas o incidencias.

### Interfaz amigable
- **ASP.NET MVC y Razor**: Construida para ser limpia y accesible a cualquier usuario, con formularios claros y validaciones básicas.
- **Diseño personalizable**: Estilos y layout que se pueden ajustar según tus necesidades, permitiendo integrar una identidad visual propia.

Con el modelo de datos adecuado, podrás aprovechar todas estas características para llevar un control exhaustivo de tus tareas o tickets.

---

## Tecnologías utilizadas
- **Lenguaje**: C#  
- **Framework**: ASP.NET MVC  
- **Base de datos**: SQL Server
- **IDE**: Visual Studio 
- **Herramientas**: Git, GitHub, .NET CLI
- **Power BI**: Proximamente se incorporaran metricas dinamicas con PBI


---

## Instalación y configuración

1. **Clonar este repositorio**  
   ```bash
   git clone https://github.com/eduardoVM137/Notas.git
