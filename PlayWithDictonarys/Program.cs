// See https://aka.ms/new-console-template for more information

Dictionary<int, string> dict = new ();
//dict.Add(1, "One");
dict.Add(2, "Two");
dict.Add(3, "Three");

Dictionary<string, string> dict2 = new ();
dict2.Add("1", "One");
//dict2.Add("2", "Two");
dict2.Add("3", "Three");


if(dict.ContainsKey(1))
    dict[1] = "Ett";
else
    dict.Add(1, "Ett");

Console.WriteLine(dict2.TryGetValue("2", out string value) ? value : "Not found");
Console.WriteLine(dict[1]);