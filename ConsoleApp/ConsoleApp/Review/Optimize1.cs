using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Review
{
    public struct BalanceResult
    {
        public int UserId;
        public decimal Balance;
    }

    public interface IBalanceGetter
    {
        BalanceResult[] GetBalances(int[] userIds);
    }

    public interface IYouNeedToImplementIt
    {
        /// <summary>Заполняет столбец balance у таблицы <paramref name="table"/>.</summary>
        /// <param name="table">Таблица. См. Remarks.</param>
        /// <param name="getter">Получатель баланса.</param>
        /// <remarks>
        /// <para>Таблица <paramref name="table"/> состоит из двух столбцов:</para>
        /// <list type="bullet">
        ///     <item>user_id (идентификатор пользователя, Int32)</item>
        ///     <item>balance (баланс пользователя, Decimal)</item>
        /// </list>
        /// <para>Столбец user_id заполнен, а столбец balance инициализирован 
        ///<see cref="DBNull.Value"/>.</para>
        /// </remarks>
        void FillBalance(DataTable table, IBalanceGetter getter);
    }

    public sealed class BadImplementation : IYouNeedToImplementIt
    {
        public void FillBalance(DataTable table, IBalanceGetter getter)
        {
            List<int> userIds = new List<int>(); //Сразу нужно создать массив, нет капасити

            foreach (DataRow row in table.Rows) //Возможно положить в хеш таблицу user_id DataRow
            {
                userIds.Add((int)row["user_id"]);
            }

            //Распараллелить
            BalanceResult[] allBalances = getter.GetBalances(userIds.ToArray()); //ToArray создает копию

            foreach (DataRow row in table.Rows)
            {
                foreach (BalanceResult balanceResult in allBalances)
                {
                    if ((int)row["user_id"] == balanceResult.UserId)
                        row["balance"] = balanceResult.Balance; //можно прервать цикл если уникальны
                }
            }
        }
    }


    public sealed class MyImplementation2 : IYouNeedToImplementIt
    {
        public async void FillBalance(DataTable table, IBalanceGetter getter)
        {
            int[] userIds = new int[table.Rows.Count]; //Сразу нужно создать массив
            Dictionary<int, DataRow> userRows = new Dictionary<int, DataRow>(userIds.Length);

            for (int i = 0; i < table.Rows.Count; i++) //Возможно положить в хеш таблицу user_id DataRow
            {
                int userId = (int)table.Rows[i]["user_id"];
                userIds[i] = userId;
            }

            //Распараллелить
            var task = Task.Run(() => getter.GetBalances(userIds));
            for (int i = 0; i < userIds.Length; i++) //Возможно положить в хеш таблицу user_id DataRow
            {
                int userId = userIds[i];
                userRows[userId] = table.Rows[i];
            }

            var allBalances = await task;

            foreach (BalanceResult balanceResult in allBalances)
            {
                var row = userRows[balanceResult.UserId];
                row["balance"] = balanceResult.Balance;
            }
        }
    }
}
