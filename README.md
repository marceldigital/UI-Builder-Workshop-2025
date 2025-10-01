# UI Builder Workshop 2025

This workshop is split into lessons which build on eachother.

- [Lesson 1: Installation](docs/lesson-1.md)
- [Lesson 2: Initial Setup and First Section](docs/lesson-2.md)
- [Lesson 3: Scaffolding Our First Collection](docs/lesson-3.md)
- [Lesson 4: Lesson 4: CRUD Entities](docs/lesson-4.md)
- [Lesson 5: Creating Child Collections](docs/lesson-5.md)
- [Lesson 6: Lesson 6: Value Mappers](docs/lesson-6.md)
- [Lesson 7: Notification Handlers](docs/lesson-7.md)

## Solution Setup
The solution is split into 3 projects. When run for the first time the nessesary tables and data should be created for you.

### UIBuilderWorkshop.Core
This is where we will be doing the bulk of the work during this workshop to configure UI Bulider. It also includes a migration script which will build the tables and seed mock data on first boot.

### UIBuilderWorkshop.Data
This is where the models are stored which we will be using in the database and to make editable in UI Builder.

### UIBuilderWorkshop.Web
This is the web application which will house any View changes which we need to add.
