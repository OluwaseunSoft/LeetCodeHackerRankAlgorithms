﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeHackerRankAlgorithms.InMemoryDatabase
{
    internal class InMemoryDb
    {
        /*Instructions
Your task is to implement a simplified version of an in-memory database. All operations that should be supported by this database are described below.

Solving this task consists of several levels. Subsequent levels are opened when the current level is correctly solved. You always have access to the data for the current and all previous levels.

Requirements
Your task is to implement a simplified version of an in-memory database. Plan your design according to the level specifications below:

Level 1: In-memory database should support basic operations to manipulate records, fields, and values within fields.
Level 2: In-memory database should support retrieving statistics about the frequency of updates to records.
Level 3: In-memory database should support multiple users and allow users to lock records.
Level 4: In-memory database should support undo and logout operations from users.
To move to the next level, you need to pass all the tests at this level when submitting the solution.

Note

You will receive a list of queries to the system, and the final output should be an array of strings representing the returned values of all queries. Each query will only call one operation.

Level 1
The basic level of the in-memory database contains records. Each record can be accessed with a unique identifier key, which is of string type. A record contains several field-value pairs, with field as string type and value as integer type.

SET_OR_INC <key> <field> <value> — should insert a field-value pair to the record associated with key. All value should be integers. If the field in the record already exists, increase the current value by the specified value. If the record or field does not exist, a new one should be created with the value set to the value. This operation should return a string representing the inserted or updated value (in this level, an empty string is never returned).

GET <key> <field> — should return a string representing the value within field of the record associated with key. If the record or the field does not exist, should return an empty string.

DELETE <key> <field> — should remove field from the record associated with key. Returns "true" if the field was deleted, and "false" otherwise. If all fields in a record have been deleted, the record should be deleted.

Examples
The example below shows how these operations should work (the section is scrollable to the right):

Queries	Explanations
queries = [
  ["SET_OR_INC", "A", "B", "5"],
  ["SET_OR_INC", "A", "B", "6"],
  ["GET", "A", "B"],
  ["GET", "A", "C"],
  ["DELETE", "A", "B"],
  ["DELETE", "A", "C"]
]

returns "5"; database state: {"A": {"B": 5}}
returns "11"; database state: {"A": {"B": 11}}
returns "11"; database state: {"A": {"B": 11}}
returns ""; as "C" is not present.
returns "true"; database state: {}
returns "false"; database state: {}

the output should be ["5", "11", "11", "", "true", "false"].

Input/Output

[execution time limit] 0.5 seconds (cs)

[memory limit] 1 GB

[input] array.array.string queries

An array of queries to the system. It is guaranteed that all the queries parameters are valid: each query calls one of the operations described in the description, all operation parameters are given in the correct format, and all conditions required for each operation are satisfied.

Guaranteed constraints:
1 ≤ queries.length ≤ 500.

[output] array.string

An array of strings representing the returned values of queries.
         */

        private readonly Dictionary<string, Dictionary<string, int>> _database;
        private readonly Dictionary<string, Dictionary<string, int>> _updateFrequency;

        public InMemoryDb()
        {
            _database = new Dictionary<string, Dictionary<string, int>>();
            _updateFrequency = new Dictionary<string, Dictionary<string, int>>();
        }

        public string CreateOrIncreaseRecord(string key, string field, string value)
        {
            if (!_database.ContainsKey(key))
            {
                _database[key] = new Dictionary<string, int>();
            }

            if (!_database[key].ContainsKey(field))
            {
                _database[key][field] = 0;
            }

            _database[key][field] += int.Parse(value);

            return _database[key][field].ToString();
        }

        public string GetRecord(string key, string field)
        {
            if (_database.ContainsKey(key) && _database[key].ContainsKey(field))
            {
                return _database[key][field].ToString();
            }

            return "";
        }

        public string DeleteRecord(string key, string field)
        {
            if (_database.ContainsKey(key) && _database[key].ContainsKey(field))
            {
                _database[key].Remove(field);
                if (_database[key].Count == 0)
                {
                    _database.Remove(key);
                }
                return "true";
            }
            return "false";
        }

        public string[] ExecuteQueries(string[][] queries)
        {
            var results = new List<string>();

            foreach (var query in queries)
            {
                string operation = query[0];
                string key = query[1];
                string field = query[2];

                switch (operation)
                {
                    case "SET_OR_INC":
                        string value = query[3];
                        results.Add(CreateOrIncreaseRecord(key, field, value));
                        break;
                    case "GET":
                        results.Add(GetRecord(key, field));
                        break;
                    case "DELETE":
                        results.Add(DeleteRecord(key, field));
                        break;
                    default:
                        throw new ArgumentException("Invalid Operation");
                }
            }

            return results.ToArray();
        }
    }
}
