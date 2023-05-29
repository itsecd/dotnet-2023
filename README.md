# Кадры предприятия, вариант 3
### Исходные данные
В отделе кадров предприятия хранятся данные о каждом сотруднике - регистрационный номер, 
фамилия, имя, отчество, дата рождения, пол, дата поступления на работу, цех (справочник), 
отдел (справочник), занимаемая должность (справочник), домашний адрес, телефоны рабочий и домашний, 
семейное положение, число человек в семье, число детей.
Один сотрудник может числиться в нескольких отделах. Отдел кадров хранит
архив данных о трудовой деятельности сотрудника: дата приема на должность,
дата увольнения с должности.

Каждый сотрудник может быть членом профсоюза. Профсоюз хранит
информацию за последние три года о сотрудниках, получивших льготные путевки
в санаторий, дом отдыха и пионерский лагерь предприятия.
Реализация проекта клиент-серверного приложения.

### Запросы:
1) Вывести всех сотрудников выбранного отдела.
2) Вывести сотрудников, работающих в нескольких отделах, упорядочить по
ФИО.
3) Вывести архив об увольнениях, включающий регистрационный номер,
ФИО, дату рождения, цех, отдел, занимаемую должность.
4) Вывести средний возраст сотрудников в каждом отделе.
5) Вывести сведения о сотрудниках, получавших в прошлом году льготные
профсоюзные путевки (с запросом вида путевки).
6) Вывести топ 5 сотрудников, имеющих наибольших стаж работы на
предприятии.

# Графический интерфейс
### Основное окно
![Окно отображения отделов](Organization/Organization.Client/ExampleImages/departments.png)
![Окно отображения цехов](Organization/Organization.Client/ExampleImages/workshops.png)
![Окно отображения сотрудников](Organization/Organization.Client/ExampleImages/employees.png)
![Окно отображения связи сотрудников и отделов](Organization/Organization.Client/ExampleImages/employeesDepartments.png)
![Окно отображения связи сотрудников и отпускных путевок](Organization/Organization.Client/ExampleImages/employeesVacationVouchers.png)
![Окно отображения связи сотрудников и должностей](Organization/Organization.Client/ExampleImages/employeesOccupations.png)
![Окно отображения отпускных путевок](Organization/Organization.Client/ExampleImages/vacationVouchers.png)
![Окно отображения типов отпускных путевок](Organization/Organization.Client/ExampleImages/voucherTypes.png)
![Окно отображения должностей](Organization/Organization.Client/ExampleImages/occupations.png)

#### Основное окно: отображение статистики
![Окно отображения результата первого запроса](Organization/Organization.Client/ExampleImages/firstStatistic.png)
![Окно отображения результата второго запроса](Organization/Organization.Client/ExampleImages/secondStatistic.png)
![Окно отображения результата третьего запроса](Organization/Organization.Client/ExampleImages/thirdStatistic.png)
![Окно отображения результата четвертого запроса](Organization/Organization.Client/ExampleImages/fourthStatistic.png)
![Окно отображения результата пятого запроса](Organization/Organization.Client/ExampleImages/fifthStatistic.png)
![Окно отображения результата шестого запроса](Organization/Organization.Client/ExampleImages/sixthStatistic.png)

### Окна изменения или добавления отдельных записей таблиц
![Окно изменения/добавления отдела](Organization/Organization.Client/ExampleImages/departmentEdit.png)
![Окно изменения/добавления цеха](Organization/Organization.Client/ExampleImages/workshopEdit.png)
![Окно изменения/добавления сотрудника](Organization/Organization.Client/ExampleImages/employeeEdit.png)
![Окно изменения/добавления связи сотрудника и отдела](Organization/Organization.Client/ExampleImages/employeeDepartmentEdit.png)
![Окно изменения/добавления связи сотрудника и отпускной путевки](Organization/Organization.Client/ExampleImages/employeeVacationVoucherEdit.png)
![Окно изменения/добавления связи сотрудника и должности](Organization/Organization.Client/ExampleImages/employeeOccupationEdit.png)
![Окно изменения/добавления отпускной путевки](Organization/Organization.Client/ExampleImages/vacationVoucherEdit.png)
![Окно изменения/добавления типа отпускной путевки](Organization/Organization.Client/ExampleImages/voucherTypeEdit.png)
![Окно изменения/добавления должности](Organization/Organization.Client/ExampleImages/occupationEdit.png)

### Примеры окон ошибок
![Окно 404 ошибки](Organization/Organization.Client/ExampleImages/error1.png)
![Окно 409 ошибки](Organization/Organization.Client/ExampleImages/error2.png)
