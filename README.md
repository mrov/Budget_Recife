# Budget Recife 2017

Job opportunity challenge project using the Recife budget of the 2017 year

Its a project for a job opportunity where i can have to get the data from http://dados.recife.pe.gov.br/dataset/despesas-orcamentarias/resource/d4d8a7f0-d4be-4397-b950-f0c991438111?inner_span=True

And had the objective of show this data in some ways

# Attention!!!

#### If you want to seed the dabatase follow the step, if dont disable it into the "appsettings.json"!!!

#### The first run of the back-end it will try to seed your database with the data, to configure this seed do the following:

##### - You have to download the data in the link above as CSV and set into the "appsettings.json" file of the back-end the fullpatch to this file

# How to run

## Database

If you need help setting a Oracle data base, here is what i've made to set it locally without installing a lot of things

- Install docker in your machine, im using windows so i've installed the docker desktop and configured it

- Use this commando to pull the Oracle Free Image: docker pull container-registry.oracle.com/database/free:latest
- - This command can take a while the Oracle Free Image is huge almost 3GB

- Then you can run your oracle container using this command: docker run --name oracledb -p 1521:1521 -e ORACLE_PWD=password
- - You can change the variables values like the name and the ORACLE_PWD for what you want, and the host port too

## Back-End

1 - Clone the project into your computer

2 - (Optional step, you can disable the DB seed into the appsettings.json file) Download the CSV into the link at the beginning of this documentation

3 - (Optional step, you can disable the DB seed into the appsettings.json file) Set the full patch into the appsettings.json file to this CSV 

4 - Be sure to have a Oracle Database running with the connection string set (Set the connection string into the appsettings.json)

5 - Install the entity core tool "dotnet tool install --global dotnet-ef --version 7.0.5"

6 - Apply the migrations using "dotnet ef database update --startup-project BudgetRecife --project ./Repository"

7 - Build the project with "dotnet build"

8 - Run the project "dotnet run --project BudgetRecife"

9 - It should show to you the Swagger documentation of the routes into https://localhost:7254/swagger

## Front-end

1 - cd to BudgetRecifeFront

2 - run npm install command to install dependencies

3 - run npm dev to run locally the project, by default it will run in http://localhost:4200/
