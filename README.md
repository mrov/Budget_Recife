# Budget Recife 2017

Job opportunity challenge project using the Recife budget of the 2017 year

Its a project for a job opportunity where i can have to get the data from http://dados.recife.pe.gov.br/dataset/despesas-orcamentarias/resource/d4d8a7f0-d4be-4397-b950-f0c991438111?inner_span=True

And had the objective of show this data in some ways

# Attention!!!

#### If you want to seed the dabatase follow the step, if dont disable it into the "appsettings.json"!!!

#### The first run of the back-end it will try to seed your database with the data, to configure this seed do the following:

##### - You have to download the data in the link above as CSV and set into the "appsettings.json" file of the back-end the fullpatch to this file

# How to run

## Back-End

1 - Clone the project into your computer

2 - Download the CSV into the link at the beginning of this documentation

3 - Set the full patch into the appsettings.json file to this csv

4 - Run the application with a Oracle Database running (Set the connection string into the appsettings.json too)

5 - Open the solution inside BudgetRecife of the back-end into the visual studio and run, it should show to you the Swagger documentation of the routes

## Front-end

1 - cd to BudgetRecifeFront

2 - run npm install command to install dependencies

3 - run npm dev to run locally the project, by default it will run in http://localhost:4200/
