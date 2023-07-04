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
   <tr>
    <td>Запрос - Вывести информацию обо всех учениках в указанном классе, упорядочить по ФИО</td>
    <td><img src="https://github.com/JirenMTA/dotnet-2023/assets/91962461/5b9bcb45-7d0a-4afb-918c-6cd8450f4f5c" alt="image"></td>
  </td>
  <tr>
    <td>Запрос - Вывести информацию обо всех предметах</td>
    <td><img src="https://github.com/JirenMTA/dotnet-2023/assets/91962461/97f5588b-11e9-4549-b2e6-fa9e2ab350c4" alt="image"></td>
  </td>
  <tr>
    <td>Запрос - Вывести топ 5 учеников по среднему баллу</td>
    <td><img src="https://github.com/JirenMTA/dotnet-2023/assets/91962461/8f4647a3-4936-496d-a472-4f220559b727" alt="image"></td>
  </td>
  <tr>
    <td>Запрос - Вывести учеников с максимальным средним баллом за указанный период</td>
    <td><img src="https://github.com/JirenMTA/dotnet-2023/assets/91962461/14b127ba-13aa-4965-b022-d32d5d8e71cc" alt="image"></td>
  </td>
  <tr>
    <td>Запрос - Вывести информацию о минимальном, среднем и максимальном балле по каждому предмету</td>
    <td><img src="https://github.com/JirenMTA/dotnet-2023/assets/91962461/ec6b1b13-75b4-465d-be16-5f2d182f4357" alt="image"></td>
  </td>
</table>
