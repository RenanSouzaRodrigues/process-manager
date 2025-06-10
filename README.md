# Process Manager v1.2.0

Process manager is a small tool to handle internal Windows processes in an easy way.
It can be used from your terminal or from another applications to start, validate and kill external
processes.

## Supported Platforms
- Windows

## Installation
- Download the latest release
- Unzip the files
- Set a system variable to the folder where you unzipped the application

## Application Commands
- ``process-manager -h`` or ``process-manager --help``
  - Display all the information you need to use the application


- ``process-manager -v`` or ``process-manager --version``
  - Display the application version
 

- ``process-manager -s <processName>`` or ``process-manager --start <processName>``
  - Start a process defined by name
 

- ``process-manager -r <processName>`` or ``process-manager --running <processName>``
  - Show if the process is currently running, and if is running, show its Process ID
 

- ``process-manager -k <processName>`` or ``process-manager --kill <processName>``
  - Kill a process defined by name
    