# Recruitment Agency

Исходные данные: В агентстве хранится информация о людях, ищущих работу (соискателях), и работодателях. Соискатель характеризуется ФИО, контактным телефоном, опытом работы, образованием, желаемым уровнем зарплаты и т.д. Каждый соискатель может претендовать на несколько должностей. Должность характеризуется разделом (IT, финансы, реклама и т.д.) и непосредственно должностью (программист, специалист по кредитованию, дизайнер, ...). Заявка соискателя характеризуется датой подачи. Работодатель характеризуется названием, ФИО контактного лица, контактным телефоном. Один работодатель может подавать заявки на несколько должностей. Заявка работодателя содержит набор требований к соискателю, предлагаемый уровень зарплаты и так же характеризуется датой подачи.

## Запросы:

Вывести сведения о всех соискателях, ищущих работу по заданной должности, упорядочить по ФИО.
Вывести всех соискателей, оставивших заявки за заданный период.
Вывести сведения о соискателях, соответствующих определенной заявке работодателя.
Вывести информацию о количестве заявок по каждому разделу и должности.
Вывести топ 5 работодателей по количеству заявок.
Вывести информацию о работодателях, открывших заявки с максимальным уровнем зарплаты.

## About the project

In this project, several classes describing the profession of a staffing agency were created.
Mysql queries (LINQ) were used to process the data, and unit tests were used to check the stability of some methods.
A server application was also created that processed CRUD operations.
Integration tests were used to check the stability of the application.
In the next phase, the data storage was migrated to the database using EF Core MySQL.
In the next phase of the project, the data warehouse was migrated to the database using EF Core MySQL.
Finally, a client application was created using avalonia, which communicates with the server application.

# Screenshots
## Application
![](/Recruitment/RecruitmentAgency/RecruitmentAgency.Client/Assets/MainWindow.png)
## Company buttons
### Company add
![](/Recruitment/RecruitmentAgency/RecruitmentAgency.Client/Assets/CompanyAdd.png)
### Company edit
![](/Recruitment/RecruitmentAgency/RecruitmentAgency.Client/Assets/CompanyEdit.png)
## Company application buttons
### Company application add
![](/Recruitment/RecruitmentAgency/RecruitmentAgency.Client/Assets/CompanyApplicationAdd.png)
### Company application edit
![](/Recruitment/RecruitmentAgency/RecruitmentAgency.Client/Assets/CompanyApplicationEdit.png)
## Job application buttons
### Job application add
![](/Recruitment/RecruitmentAgency/RecruitmentAgency.Client/Assets/JobApplicationAdd.png)
### Job application edit
![](/Recruitment/RecruitmentAgency/RecruitmentAgency.Client/Assets/JobApplicationEdit.png)
## Employee buttons
### Employee add
![](/Recruitment/RecruitmentAgency/RecruitmentAgency.Client/Assets/EmployeeAdd.png)
### Employee edit
![](/Recruitment/RecruitmentAgency/RecruitmentAgency.Client/Assets/EmployeeEdit.png)
## Title buttons
### Title add
![](/Recruitment/RecruitmentAgency/RecruitmentAgency.Client/Assets/TitleAdd.png)
### Title edit
![](/Recruitment/RecruitmentAgency/RecruitmentAgency.Client/Assets/TitleEdit.png)
