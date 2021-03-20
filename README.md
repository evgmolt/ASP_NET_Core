# ASP.NET Core Web API микросервисы. MetricsManager

## Урок 1. Практическое задание. Контроллер для работы с данными (температура)
### Запросы:
Вместо [XXX] подставить нужную строку

Сохранить температуру в указанное время:
POST http://localhost:5000/api/temperature/create?temperatureS=[value]&datetimeS=[datetime]
Если второго параметра нет, устанавливается текущее время.

Прочитать весь список показателей температуры
GET http://localhost:5000/api/temperature/read

Прочитать список показателей температуры за указанный промежуток времени
GET http://localhost:5000/api/temperature/readinterval?timeFrom=[datetime]&timeTo=[datetime]

Отредактировать показатель температуры в указанное время
PUT http://localhost:5000/api/temperature/update?timeToChange=[datetime]&newTemp=[value]
Если время не найдено, возмвращается Bad Request. Ниже так же. Неправильно?

Удалить показатель температуры в указанное время
DELETE http://localhost:5000/temperature/delete?timeToDelete=[datetime]

Удалить показатель температуры в указанный промежуток времени
DELETE http://localhost:5000/api/temperature/deleteinterval?timeFrom=[datetime]&timeTo=[datetime]