## 15. «Электронный дневник учащихся»
**Исходные данные:
В базе данных школы содержится информация о классах (номер, литера), 
предметах (название, год обучения), учениках (паспорт, ФИО, дата рождения, 
класс) и оценках. При выставлении оценки в базу данных вносится информация об 
ученике, оценке, предмете и дате**

## Описание сущностей модели
1. `LibrarySchool.Domain` - Библиотеки, объявляющие используемые классы (`Student`, `ClassType`, `Mark`, `Subject`).
2. `LibrarySchool.Test` - `Unit test` для методов сервера
3. `LibrarySchool.Server` - Сервер `Web API`, подключаюший к базе данных `MySQL`
4. `LibrarySchool.Client` - Клиент, создаваемый с использованием `avaloniaUI`

## Описание API сервера
 - Сервер содержит в себе 4 главных контроллеров: `StudentController`, `ClassTypeController`, `MarkController`, `SubjectController` и котроллер `QuerryController` для собственных запросов
 - В главных контроллерах объявляются 5 методов: Get, Get by Id, Post, Put, Delete
 - В контроллере `QuerryController` объявляют методы:
   1. Вывести информацию обо всех предметах
   2. Вывести информацию обо всех учениках в указанном классе, упорядочить по ФИО
   3. Вывести топ 5 учеников по среднему баллу.
   4. Вывести учеников с максимальным средним баллом за указанный период.
   5. Вывести информацию о минимальном, среднем и максимальном балле по каждому предмету.

## Описание клиента
  - Клиент пишется на `avalonia UI`
  - Реализуюся все возможные запросы к серверу
  - Способ организации кода - MVVM

## Шкриншоты клиента

<table>
  <tr>
    <th>Название</th>
    <th>Шкриншот</th>
  </tr>
  <tr>
    <td>Главное окно</td>
    <td><img src="https://github.com/JirenMTA/dotnet-2023/assets/91962461/7eb8c556-e6be-404b-a5d6-885e3b2e2fc9" alt="image"></td>
  </tr>
  <tr>
    <td>Добавление</td>
    <td><img src="https://github.com/JirenMTA/dotnet-2023/assets/91962461/111635ba-e11d-456e-99f3-986870b640f5" alt="image"></td>
  </tr>
  <tr>
    <td>Редактирование</td>
    <td><img src="https://github.com/JirenMTA/dotnet-2023/assets/91962461/3677b9f1-6e50-47ab-b077-015583df54f2" alt="image"></td>
  </tr>
  <tr>
    <td>Удаление</td>
    <td><img src="https://github.com/JirenMTA/dotnet-2023/assets/91962461/9149d624-aee4-4b19-96fd-a19f80cf11de" alt="image"></td>
  </tr>
  <tr>
    <td>Запросы</td>
    <td><img src="https://github.com/JirenMTA/dotnet-2023/assets/91962461/158adf03-3218-43b2-9f31-e7750471ed9b" alt="image"></td>
  </tr>
</table>
