# Unity Multi-Layer Architecture Project

## About The Project

This project is an exploration of multi-layer architecture within the Unity game engine framework. By structuring the code into multiple layers with separate `.asmdef` assemblies, we aim to foster a clean separation of concerns and enforce proper dependency flow between the various components of the architecture.

## Features

The project includes the following features:

- Multi-layered architecture demonstration
- Basic UI functionality
- Simplified gameplay loop
- Local high score persistence across sessions
- WebGL build available for demonstration purposes

### Layers Overview

- **Application**: Contains the application logic and orchestrates the flow between the user interface and the underlying data processing.
- **Infrastructure.Core**: Provides core functionality and integrations.
- **Presentation.Core**: Manages the presentation logic and interactions with the user interface.
- **Controllers.Core**: Handles user input and system events, mapping actions to the application's logic.
- **Common**: Contains common utilities and shared resources that can be used across all layers.
- **Infrastructure.Api**: Exposes APIs for the infrastructure services.
- **Controllers.Api**: Offers a set of APIs for the controllers layer to interact with the rest of the system.
- **Domain**: Defines the business logic and data models which represent the problem domain.
   

### Goals

The main goal of this project is to showcase how a multi-layered architectural approach can lead to more maintainable and scalable Unity applications. By adhering to this structure, developers can prevent undesirable dependencies and enforce a clean separation of concerns.

### Caveats

This project is a stripped-down example to demonstrate the architectural principles in a compact form. It does not address every possible aspect such as:

- Responsive UI design
- Visual and Audio Effects systems
- Other advanced features

Additionally, all purchased visual assets have been removed from this repository to avoid copyright issues. However, a link to a WebGL build is provided to give you an idea of how the application should operate visually.

## Viewing the Project

A [WebGL build](https://klavikus.github.io/UnityMultilayerArchitectureDemo/Builds/index.html) is available to see the project in action.

The source code is available in this repository for those who are interested in the codebase.

### Requirements

- Unity Editor version 2022.3.3f1 or newer.
- .NET Standard 2.0 compatible IDE for editing the code (e.g., Visual Studio, Visual Studio Code, Rider).
