Console.Title = "installer.msi";
Console.WriteLine("Welcome to look busy!");//randomises keywords and creates something that looks busy ish
Console.WriteLine("Press enter to begin looking busy");
Console.ReadKey();
Console.Clear();
string location=System.Reflection.Assembly.GetEntryAssembly().Location.Replace("LookBusy\\LookBusy\\bin\\Debug\\net6.0\\LookBusy.dll","");
string[] firstlocation = {"bin","netcore","main","0978EAFC6J","tomisgayontuesdays","connorisaplankofwood","canoflarger","tomisatom"};
string[] secondlocation = {"debug","longdancee","legocity","legolass","gandalf","danisachad","012139123EASDJGSDIS"};
string[] thirdlocation = {"net6.0","img","css","core","lib","repository","git","prettysusbrowhywouldyouevendothat","71821EABAF"};
string[] forthlocation= {"vs_installer.msi","index.html","main.css","console.sln","pain.exe"};
string[] start = { "Extracting from", "Converting","Refactoring","Reset base","Deleting" };
string[] end = { "from locale...","index value revoked...","repromanded...","inversion intiated..." };
Random rand = new Random();
while (true) 
{
    Console.WriteLine(start[rand.Next(start.Length)]+" " + location + firstlocation[rand.Next(firstlocation.Length)]+"\\" + secondlocation[rand.Next(secondlocation.Length)] + "\\" + thirdlocation[rand.Next(thirdlocation.Length)] + "\\" + forthlocation[rand.Next(forthlocation.Length)] +" " + end[rand.Next(end.Length)]);
    Thread.Sleep(rand.Next(100, 500));
}