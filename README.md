Проекты FileManager и ConfigurationManager разработонные ранее для отслеживания добавленных в папку файлов и получения конфигурационных свойств соответственно.
Проект Model содержит модели для работы с данными в DataAccessLayer с помощью классов Repository.
Проект DаtaAccessLayer служит для работы с данными из базы данных.
Проект ServiceLayer на основе данных полученных из DаtaAccessLayer создаёт коллекцию объектов RequiredInformation(в ServiceOrder), с которой работает DataManager.
В DataManager XmlTransfer генерирует xml файл, FileTransfer отправляет его на FTP сервер.
