
# MouseTracker

**MouseTracker** — это приложение для отслеживания движения мыши пользователя и сохранения координат и времени этих движений. Данные отправляются и сохраняются в базе данных, и могут быть использованы для анализа.

## Описание

Этот проект позволяет отслеживать движения мыши на веб-странице, сохранять данные (координаты X, Y и время события) и отправлять их на сервер для дальнейшей обработки. Он использует ASP.NET Core для создания API и Entity Framework для работы с базой данных.

## Структура проекта

Проект состоит из нескольких основных частей:

- **MouseTracker.Web** — основной веб-приложение на ASP.NET Core, включающее фронтенд для отслеживания движения мыши.
- **MouseTracker.Application** — сервисы и бизнес-логика, включая сохранение и обработку данных.
- **MouseTracker.Domain** — сущности и интерфейсы, описывающие основные объекты и взаимодействия.
- **MouseTracker.Infrastructure** — взаимодействие с базой данных и хранение данных.

## Структура каталогов

```
MouseTracker/
│
├── MouseTracker.Web/               # Веб-часть проекта (ASP.NET Core)
│   ├── wwwroot/                    # Статические файлы (HTML, CSS, JS)
│   ├── Views/                      # Представления Razor
│   ├── Controllers/                # Контроллеры API
│   ├── Pages/                      # Страницы Razor
│   └── Program.cs                  # Главная точка входа в веб-приложение
│
├── MouseTracker.Application/       # Логика приложения
│   ├── Services/                   # Сервисы обработки данных
│   └── DTOs/                       # Data Transfer Objects (DTO)
│
├── MouseTracker.Domain/            # Доменные сущности и интерфейсы
│   ├── Entities/                   # Сущности (например, MouseMovement)
│   └── Interfaces/                 # Интерфейсы репозиториев
│
└── MouseTracker.Infrastructure/    # Взаимодействие с базой данных
    ├── Persistence/                # Контекст базы данных и миграции
    └── Repositories/               # Реализация репозиториев
```

## Установка

1. Клонируйте репозиторий:

   ```bash
   git clone https://github.com/your-username/MouseTracker.git
   cd MouseTracker
   ```

2. Убедитесь, что у вас установлен .NET SDK 8.0 или выше.

3. Выполните восстановление зависимостей:

   ```bash
   dotnet restore
   ```

4. Создайте базу данных и примените миграции:

   ```bash
   dotnet ef database update
   ```

5. Запустите проект:

   ```bash
   dotnet run
   ```

   Веб-приложение будет доступно по адресу: `https://localhost:5001`.

## Страница с движением мыши

Приложение будет отслеживать движения мыши, и когда вы нажмете кнопку "Отправить данные", координаты и время будут отправлены на сервер.

## Тестирование

Для тестирования проекта использован **xUnit** и **Moq**. Чтобы запустить тесты, выполните команду:

```bash
dotnet test
```

Тесты проверяют правильность сохранения и обработки данных.

## Технологии

- **ASP.NET Core** — для построения веб-приложения.
- **Entity Framework Core** — для работы с базой данных.
- **xUnit** — для юнит-тестирования.
- **Moq** — для создания заглушек и моков в тестах.

## Структура данных

Каждое событие отслеживания мыши представляет собой объект с полями:

- `X`: координата X на экране.
- `Y`: координата Y на экране.
- `T`: время события, отсчитываемое с момента старта приложения (в миллисекундах).

Пример сохраненных данных:

```json
[
  {"X": 10, "Y": 20, "T": 700},
  {"X": 30, "Y": 40, "T": 710}
]
```

## Важные файлы

- **Program.cs** — настройка старта приложения и конфигурации.
- **Startup.cs** — конфигурация зависимостей и сервисов (в случае использования).
- **Migrations** — миграции базы данных, которые могут быть применены на других машинах.
- **.gitignore** — игнорирование файлов базы данных (например, SQLite) и временных данных.


