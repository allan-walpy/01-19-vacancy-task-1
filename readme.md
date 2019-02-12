# 01-19-vacancy-task-1

## Задание

Реализовать приложение для формирования списка вакансий с поиском по нему. Вакансия характеризуется следующими атрибутами: заголовок, оклад, организация разместившая вакансию, контактное лицо, телефон, тип занятости, описание вакансии.

## Стек технологий

> к сожалению, в моём распоряжении только linux (xubuntu 18.04) машина *(в силу изношености корпуса ноутбука он быстро перегревается)* и я физически не могу разрабатывать под не `.Net Core` и пользоваться `Visual Studio`

### Инструменты разработки

- `vs code`;
  - `formulahendry.dotnet-test-explorer` - расширение для обнаружения и запуска тестов;
- `dotnet cli`;

### Стек технологий приложения

Приложение реализованно с помощью:

- `Asp.Net Core` v2.2.1;
  - `Asp,Net Core MVC`;
  - `Razor Pages in Asp.Net Core`;
  - `Newtonsoft.Json` (является частью asp.net core v2 и выше);
- `Entity Framework Core`;
  - `MySql`;
- `Swashbuckle.AspNetCore` v5.0.0-beta (openapi v3.0.1);
- `Xunit` (тесты);

## О приложении

Приложение реализованно одновременно как rest api приложение и как web приложение/сайт c формами для управления.

Данное приложение развернуто на моём собственном сервере по адрессу [https://vacancy.walpy.cf/](https://vacancy.walpy.cf/)

### Код и исполняемые файлы

Исходный код: [https://github.com/allan-walpy/01-19-vacancy-task-1.git](https://github.com/allan-walpy/01-19-vacancy-task-1.git)

Исполняемые файлы:

- [`ubuntu 18.04 x64` published self-contained версия](https://github.com/allan-walpy/01-19-vacancy-task-1/releases/download/v1.2.7/self-contained.ubuntu.18.04-x64.zip)
- [`windows 10 x64` published self-contained версия](https://github.com/allan-walpy/01-19-vacancy-task-1/releases/download/v1.2.7/self-contained.win10-x64.zip)

Для функционирования программы необходимо скопировать [файл `appsettings.private.example.json`](https://github.com/allan-walpy/01-19-vacancy-task-1/blob/master/src/appsettings.private.example.json) в `appsettings.private.json` и указать необходимые настройки:

- `HOST` (для локального использования `localhost:5099`)
  > используется Redoc UI для скачивания openapi спецификации по адрессу `https://{HOST}/api/openapi.json`

- `debugClient` - если установлен в `true` - включает Swagger UI по адрессу `/api/debug` даже при конфигурации `Release`
  > по адрессу `https://vacancy.walpy.cf/` приложение работает в конфигурации `Release`, но через данную настройку в нём можно использовать Swagger UI. Так же данная настройка не влияет на отображение пункта меню Swagger в web версии (как и текущая конфигурация приложения)

- `ConnectionStrings:database:debug` и `ConnectionStrings:database:production` - команды подключения к базе данных (используется mysql) для `Debug` и `Release` конфигураций приложения соответственно;
  > Приложение закончит работу с ошибкой если не создать в mysql базу данных с указанным именем (при этом не нужно создавать таблицы и т.д.); Для этого можно, например, в mysql shell прописать `CREATE DATABASE appDatabase CHARACTER SET UTF8mb4 COLLATE utf8mb4_general_ci;` (для поддержки юникода а также специальных символов вроде unicode emojie)

### Api

Документация по api приложения доступно по адрессам:

- [OpenApi specification json file](https://vacancy.walpy.cf/api/openapi.json);
- [Redoc UI](https://vacancy.walpy.cf/web/home/help);
- [Swagger UI](https://vacancy.walpy.cf/api/debug);
    > Известные баги Swagger UI: при сворачивании/разворачивании секции GET запроса, другая секция с GET запросом так же разворачивается (`GET api/vacancy/` & `GET api/vacancy/{id}`)

### Web

> Известные баги: не работает дефолтное рутирование, т.е. `/{controller}/` не перенаправляет на `/{controller}/index`, `/` -> `/home/index`

Приложение доступно по адрессу [https://vacancy.walpy.cf/web/home/index](https://vacancy.walpy.cf/web/home/index)

- [CRUD вакансий](https://vacancy.walpy.cf/web/vacancy/index);
- [Поиск по вакансиям](https://vacancy.walpy.cf/web/search/index);

## Билды и тесты в CI системах для опенсорс

`Travis CI` и `Appveyor CI` были использованны для облегчения разработки

> Известные баги:
>
> - довольно продолжительное исполнение тестов на windows (возможно связанное с `EF Core In Memmory Database`);
> - исполнение всех тестов сразу приведет к ошибке `Connection Refused`, для `workaround` они запускаются пачками - [пример bash скрипта для запуска тестов](https://github.com/allan-walpy/01-19-vacancy-task-1/blob/master/script/test.sh)

| CI & Platform | Status |
| ------------: | :----- |
| [![travis:linux](https://img.shields.io/badge/travis-ubuntu-blue.svg?longCache=true&style=for-the-badge)](https://travis-ci.com/) | [![travis build](https://img.shields.io/travis/com/allan-walpy/01-19-vacancy-task-1.svg?style=for-the-badge)](https://travis-ci.com/allan-walpy/01-19-vacancy-task-1) |
| [![appveyor:windows](https://img.shields.io/badge/appveyor-windows-blue.svg?longCache=true&style=for-the-badge)](https://ci.appveyor.com/) | [![appveyor build](https://img.shields.io/appveyor/ci/allan-walpy/01-19-vacancy-task-1.svg?style=for-the-badge)](https://ci.appveyor.com/project/allan-walpy/01-19-vacancy-task-1) |