# ofx-reader
## Application to read transactions with ofx file extension



### How to start the db with docker:

Access the folder enviroment via terminal the execute:

`docker build -t mysql .`

When the image is ready you can run it with:

`docker run mysql`

*If you want to use an mysql standart installation all db information is on dockerfile and on folder scripts*

### How to run it:

`dotnet restore`

`npm install`

Then just start it from the GUI, or you can run it via terminal with:

`dotnet build`

`dotnet run`
