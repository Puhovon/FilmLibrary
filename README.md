# FilmLibrary
Приложение создано для освоения паттерна MVVM, а так же оно пойдет в мое портфолио.

## Идея
Мне уже давно надоели горы скриншотов фильмов, которые я нашел в ютубе или где-либо ещё, поэтому я решил создать данное приложение
В него можно добавлять фильмыы которые хочешь посмотреть/уже посмотрел
Так же мне очень хотелось попробовать реализовать паттерн Model-View-ViewModel(MVVM)


## Основные функции
<ul>
<li>Добавление новых фильмов</li>
<li>Редактировние существующих фильмов</li>
<li>Удаление фильмов из бд</li>
<li>Просмотр строки подключения</li>
</ul>

### Установка бд (в моем случае, в файле Context стоит пароль 123, в случае необходимости заменить)
Я добавил несколько SQL файлов, поэтому вот небольшая инструкция, как её создать:
1. Открываем PgAdmin(В моем случае это 4 версия и пример буду показывать с ней) и вводим пароль
2. Кликаем ПКМ по базе данных(если её нет, то создаем и называем "postgres") и выбираем Query Tool
![image](https://user-images.githubusercontent.com/91030077/227734533-e4f6a5c1-2254-4ff0-894e-926b6169c8bc.png)
3. В левом верхнем углу открывшейся панели нажимаем Open File
![image](https://user-images.githubusercontent.com/91030077/227734982-f9fe090d-8cfe-4c14-8c87-1c44b5dc55c1.png)

4. Открываем нужный нам файл(CreateTableScript) 
5. Нажимаем F5 или кнопку запуска скрипта

