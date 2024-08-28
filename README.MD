# Cargo Load Management Application

## Project Description
Develop a web application for managing cargo loads in the transportation sector. The application consists of a frontend built with React and a backend powered by .NET. The goal is to provide an intuitive interface for tracking cargo details, with features for adding, viewing, and exporting load information.

## Requirements

### General Structure
- The application includes a multi-page user interface.
- A navigation menu is available for easy access to different sections of the app.

### Page 1: Cargo Load Management
- **Table View**: Displays all saved cargo load entries in a table.
- **Add New Load**: Provides a button that opens a form to input new cargo load details. The form includes the following fields:
  - Driver's full name
  - Vehicle number
  - Vehicle type (options: truck, cistern, tent)
  - Load weight
  - Dangerous Goods (ADR) checkbox to indicate if the load is hazardous
- **Real-Time Updates**: Upon saving a new load entry, the table updates immediately without requiring a page refresh.

### Page 2: Export Cargo Loads
- **Selection Dropdown**: Includes a dropdown menu that allows users to select multiple cargo loads from the list.
- **Export Functionality**: Provides an export button (represented as an image or icon) that, when clicked, generates and downloads a document containing the selected cargo load details.

## Technical Requirements
- **Frontend**: React
- **Backend**: .NET

This setup ensures a smooth user experience for managing and exporting transportation data.

## Getting Started

### Prerequisites
- Node.js
- .NET SDK

### Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/PovilasU/Vykom.git
   
   
   
   ## Video Demonstration

Watch the video demonstration of the application [here](https://www.youtube.com/watch?v=xr1WbO_N-0Y).
