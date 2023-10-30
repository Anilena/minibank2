### Просто оставлю это здесь ###

Сделал деплой двух сервисов: minibank_account_api и minibank_client_api

#### Запуск: ####
```bash
docker compose -f ./deploy/docker-compose.yml up -d
```

Приложения развернуться на двух портах:
- account_api - http://localhost:9081
- client_api - http://localhos:9082

Пришлось поменять Docker-файлы. Я люблю Microsoft, но
их шаблон для docker-файла для деплоя не пригоден.

Еще чутка поменял в контроллере немного))) Ну извиини. Это я не умничал. Просто не работали
ручки. Приложение пятисотило.

#### Удаление: ####
```bash
docker compose -f ./deploy/docker-compose.yml down
```

### Дополнительные команды: ###
```bash
docker ps
```
```bash
docker logs container_name
```

Показать все контейнеры и посмотреть лог

##### Пример ####
Выполнили превую команду и получили список контейнеров

|  CONTAINER ID |  IMAGE              |  COMMAND                 |  CREATED        |  STATUS        |  PORTS                | NAMES       |
|---------------|---------------------|--------------------------|-----------------|----------------|-----------------------|-------------|
| 1ee4855a816c  | deploy-account_api  |  "dotnet minibank_acc…"  | 6 minutes ago   | Up 6 minutes   | 0.0.0.0:9081->80/tcp  | account_api |
| 588f7424c68d  | deploy-client_api   |  "dotnet minibank_cli…"  | 28 minutes ago  | Up 28 minutes  | 0.0.0.0:9082->80/tcp  | client_api  |

Дальше по имени контейнера можем посмотреть логи в нем
```bash
docker logs account_api
```

Вроде как все. Если есть какие-то вопросы, всегда рад.