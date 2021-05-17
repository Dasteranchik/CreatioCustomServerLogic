using System;
using Terrasoft.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatioCustomServerLogic
{
    public class MyContactCreator : IExecutor
    {
        public void Execute(UserConnection userConnection)
        {
            // Получение экземпляра схемы [Контакты].
            var schema = userConnection.EntitySchemaManager.GetInstanceByName("Contact");
            var length = 10;
            for (int i = 0; i < length; i++)
            {
                // Создание нового контакта.
                var entity = schema.CreateEntity(userConnection);
                // Установка свойств контакта.
                entity.SetColumnValue("Name", string.Format("Name {0}", i));
                entity.SetDefColumnValues();
                // Сохранение контакта в базу данных.
                entity.Save(false);
            }
            // Вывод сообщения в консоль.
            Console.WriteLine($"{length} contacts created");
        }
    }
}
