using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.DTO;
using WpfApp15.Tools;

namespace WpfApp15.Model
{
    public class SqlModel
    {
        private SqlModel() { }
        static SqlModel sqlModel;
        public static SqlModel GetInstance()
        {
            if (sqlModel == null)
                sqlModel = new SqlModel();
            return sqlModel;
        }

        internal List<curator> SelectCuratorByGroup(Group selectedGroup)
        {
            throw new NotImplementedException();
        }

        internal List<Student> SelectStudentsByGroup(Group selectedGroup)
        {
            int id = selectedGroup?.ID ?? 0;
            var students = new List<Student>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `student` WHERE group_id = {id}";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        students.Add(new Student
                        {
                            ID = dr.GetInt32("id"),
                            FirstName = dr.GetString("firstName"),
                            LastName = dr.GetString("lastName"),
                            PatronymicName = dr.GetString("patronymicName"),
                            GroupId = dr.GetInt32("group_id"),
                            Birthday = dr.GetDateTime("birthday")
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return students;
        }

        internal List<discipline> SelectDisciplinesByGroup(discipline selectedDiscipline)
        {
            int id = selectedDiscipline?.ID ?? 0;
            var disciplines = new List<discipline>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `discipline` WHERE group_id = " +
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        disciplines.Add(new discipline
                        {
                            ID = dr.GetInt32("prepod_id"),
                            Title = dr.GetString("title")
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return  disciplines;
        }

        internal List<curator> SelectCuratorsByGroup(curator SelectCurator)
        {
            int id = SelectCurator?.ID ?? 0;
            var curator = new List<curator>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `curator`";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        curator.Add(new curator
                        {
                            FirstName = !dr.IsDBNull(1) ? dr.GetString("firstName") : "",
                            LastName = !dr.IsDBNull(2) ? dr.GetString("lastName") :"",
                            Birthday = dr.GetDateTime("birthday")
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return curator;
        }


        internal List<Special> SelectSpecialsByGroup(Group selectedGroup)
        {
            int id = selectedGroup?.ID ?? 0;
            var specials = new List<Special>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `specials`";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        specials.Add(new Special
                        {
                            ID = dr.GetInt32("id"),
                            Title = dr.GetString("title"),
                            
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return specials;
        }

        internal List<prepod> SelectPrepodsByGroup(Group selectedGroup)
        {
            int id = selectedGroup?.ID ?? 0;
            var prepods = new List<prepod>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `specials`";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        prepods.Add(new prepod
                        {
                            ID = dr.GetInt32("id"),
                            
                        });
                    }
                }
                mySqlDB.CloseConnection();
            }
            return prepods;
        }

        //INSERT INTO `group` set title='1125', year = 2018;
        // возвращает ID добавленной записи
        public int Insert<T>(T value)
        {
            string table;
            List<(string, object)> values;
            GetMetaData(value, out table, out values);
            var query = CreateInsertQuery(table, values);
            var db = MySqlDB.GetDB();
            // лучше эти 2 запроса объединить в один с помощью транзакции
            int id = db.GetNextID(table);
            db.ExecuteNonQuery(query.Item1, query.Item2);
            return id;
        }
        // обновляет объект в бд по его id
        public void Update<T>(T value) where T : BaseDTO
        {
            string table;
            List<(string, object)> values;
            GetMetaData(value, out table, out values);
            var query = CreateUpdateQuery(table, values, value.ID);
            var db = MySqlDB.GetDB();
            db.ExecuteNonQuery(query.Item1, query.Item2);
        }

        public void Delete<T>(T value) where T : BaseDTO
        {
            var type = value.GetType();
            string table = GetTableName(type);
            var db = MySqlDB.GetDB();
            string query = $"delete from `{table}` where id = {value.ID}";
            db.ExecuteNonQuery(query);
        }

        public int GetNumRows(Type type)
        {
            string table = GetTableName(type);
            return MySqlDB.GetDB().GetRowsCount(table);
        }

        private static string GetTableName(Type type)
        {
            var tableAtrributes = type.GetCustomAttributes(typeof(TableAttribute), false);
            return ((TableAttribute)tableAtrributes.First()).Table;
        }

        public List<Group> SelectGroupsRange(int skip, int count)
        {
            var groups = new List<Group>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `group`";
            if (mySqlDB.OpenConnection())
            {
                using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        groups.Add(new Group
                        {
                            ID = dr.GetInt32("id"),
                            Title = dr.IsDBNull(1) ? "" : dr.GetString("title"),
                            Year = dr.IsDBNull(2) ? 0 :  dr.GetInt32("year")
                        }) ;
                    }
                }
                mySqlDB.CloseConnection();
            }
            return groups;
        }

        private static (string, MySqlParameter[]) CreateInsertQuery(string table, List<(string, object)> values)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"INSERT INTO `{table}` set ");
            List<MySqlParameter> parameters = InitParameters(values, stringBuilder);
            return (stringBuilder.ToString(), parameters.ToArray());
        }

        private static (string, MySqlParameter[]) CreateUpdateQuery(string table, List<(string, object)> values, int id)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"UPDATE `{table}` set ");
            List<MySqlParameter> parameters = InitParameters(values, stringBuilder);
            stringBuilder.Append($" WHERE id = {id}");
            return (stringBuilder.ToString(), parameters.ToArray());
        }

        private static List<MySqlParameter> InitParameters(List<(string, object)> values, StringBuilder stringBuilder)
        {
            var parameters = new List<MySqlParameter>();
            int count = 1;
            var rows = values.Select(s =>
            {
                parameters.Add(new MySqlParameter($"p{count}", s.Item2));
                return $"{s.Item1} = @p{count++}";
            });
            stringBuilder.Append(string.Join(',', rows));
            return parameters;
        }

        private static void GetMetaData<T>(T value, out string table, out List<(string, object)> values)
        {
            var type = value.GetType();
            var tableAtrributes = type.GetCustomAttributes(typeof(TableAttribute), false);
            table = ((TableAttribute)tableAtrributes.First()).Table;
            values = new List<(string, object)>();
            System.Reflection.PropertyInfo[] propertyInfos = type.GetProperties();
            System.Reflection.PropertyInfo[] props = propertyInfos;
            foreach (var prop in props)
            {
                var columnAttributes = prop.GetCustomAttributes(typeof(ColumnAttribute), false);
                if (columnAttributes.Length > 0)
                {
                    string column = ((ColumnAttribute)columnAttributes.First()).Column;
                    values.Add(new(column, prop.GetValue(value)));
                }
            }
        }
    }
}
