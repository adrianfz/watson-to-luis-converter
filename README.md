# watson-to-luis-converter

Script to convert an watson conversation workspace to a LUIS Model, importing the Intents and Entities.

### System Requirements

* donet core (https://www.microsoft.com/net/learn/get-started)

### How to run it
1. Clone the repository and go to the solution folder
2. Run the commmand

    ```dotnet run --project Psbds.WLConverter.Console INPUT_FILE OUTPUT_DIRECTORY```

    Ex:
    ```dotnet run --project Psbds.WLConverter.Console "D:/workspace-watson.json" "D:"```


