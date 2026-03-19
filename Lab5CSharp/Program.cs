using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("Lab5 C# ");

Console.WriteLine("\n=== ЗАВДАННЯ 1.14 та 2.14: Тварини ===");

Tvarina tvaryna1 = new Savets("Загальна", 5, 100, true);
tvaryna1.Show();

Savets savets1 = new Savets("Вовк", 3, 50, true);
savets1.Show();

Parnokopytne parnokopytne1 = new Parnokopytne("Олень", 4, 120, true, 4);
parnokopytne1.Show();

Ptakh ptakh1 = new Ptakh("Орел", 2, 5, true, 200);
ptakh1.Show();

Console.WriteLine("\n--- Поліморфізм ---");
Tvarina[] tvaryny = new Tvarina[4];
tvaryny[0] = new Savets("Лев", 5, 200, true);
tvaryny[1] = new Parnokopytne("Кінь", 6, 450, true, 4);
tvaryny[2] = new Ptakh("Сокіл", 3, 2, true, 150);
tvaryny[3] = new Savets("Тигр", 4, 180, true);

foreach (Tvarina t in tvaryny)
{
    t.Show();
    Console.WriteLine($"Швидкість: {t.ObchyslytyShvydkist():F2}");
}

Console.WriteLine("\n=== ЗАВДАННЯ 3.4: Транспортні засоби ===");

Trans[] transport = new Trans[5];
transport[0] = new Lehkova_mashyna("Toyota", "AA-1234", 180, 500);
transport[1] = new Mototsykl("Honda", "AB-5678", 120, 200, true);
transport[2] = new Mototsykl("Yamaha", "AC-9012", 140, 150, false);
transport[3] = new Vantazhivka("Volvo", "AD-3456", 90, 5000, false);
transport[4] = new Vantazhivka("Scania", "AE-7890", 85, 8000, true);

Console.WriteLine("\n--- Всі транспортні засоби ---");
foreach (Trans t in transport)
{
    t.Show();
    Console.WriteLine($"Фактична вантажопідйомність: {t.OtrymatyVantazhopidiomnist():F2} кг");
}

Console.WriteLine("\n--- Пошук за вантажопідйомністю (>= 1000 кг) ---");
double minimalnaVantazhopidiomnist = 1000;
foreach (Trans t in transport)
{
    if (t.OtrymatyVantazhopidiomnist() >= minimalnaVantazhopidiomnist)
    {
        t.Show();
    }
}

Console.WriteLine("\n=== ЗАВДАННЯ 4.14: Стадіон (Структури, Кортежі, Записи) ===");

Console.WriteLine("\n--- Варіант 1: Структури ---");

Stadion_Struktura[] stadionyStruktura = new Stadion_Struktura[5]
{
    new Stadion_Struktura("Олімпійський", "Київ, вул. Велика Васильківська", 70050, new string[] { "Футбол", "Легка атлетика" }),
    new Stadion_Struktura("Арена Львів", "Львів, вул. Стрийська", 34915, new string[] { "Футбол" }),
    new Stadion_Struktura("Металіст", "Харків, вул. Клочківська", 40003, new string[] { "Футбол", "Регбі" }),
    new Stadion_Struktura("Чорноморець", "Одеса, вул. Канатна", 34164, new string[] { "Футбол" }),
    new Stadion_Struktura("Дніпро-Арена", "Дніпро, вул. Старокозацька", 31003, new string[] { "Футбол", "Концерти" })
};

Console.WriteLine("Початковий масив структур:");
foreach (var s in stadionyStruktura)
{
    s.Show();
}

string vydalutyNazva = "Металіст";
var spysokStruktura = new List<Stadion_Struktura>(stadionyStruktura);
spysokStruktura.RemoveAll(s => s.Nazva == vydalutyNazva);

Stadion_Struktura novyiStadion1 = new Stadion_Struktura("НСК Олімпійський", "Київ, центр", 75000, new string[] { "Футбол", "Легка атлетика", "Концерти" });
Stadion_Struktura novyiStadion2 = new Stadion_Struktura("Україна", "Львів, центр", 35000, new string[] { "Футбол", "Концерти" });
spysokStruktura.Insert(2, novyiStadion1);
spysokStruktura.Insert(3, novyiStadion2);

stadionyStruktura = spysokStruktura.ToArray();

Console.WriteLine($"\nПісля видалення '{vydalutyNazva}' та додавання 2 елементів після індексу 2:");
foreach (var s in stadionyStruktura)
{
    s.Show();
}

Console.WriteLine("\n--- Варіант 2: Кортежі ---");

var stadionyKortezh = new List<(string, string, int, string[])>
{
    ("Олімпійський", "Київ, вул. Велика Васильківська", 70050, new string[] { "Футбол", "Легка атлетика" }),
    ("Арена Львів", "Львів, вул. Стрийська", 34915, new string[] { "Футбол" }),
    ("Металіст", "Харків, вул. Клочківська", 40003, new string[] { "Футбол", "Регбі" }),
    ("Чорноморець", "Одеса, вул. Канатна", 34164, new string[] { "Футбол" }),
    ("Дніпро-Арена", "Дніпро, вул. Старокозацька", 31003, new string[] { "Футбол", "Концерти" })
};

Console.WriteLine("Початковий масив кортежів:");
foreach (var s in stadionyKortezh)
{
    Console.WriteLine($"Стадіон: {s.Item1}, Адреса: {s.Item2}, Місткість: {s.Item3}, Види спорту: {string.Join(", ", s.Item4)}");
}

stadionyKortezh.RemoveAll(s => s.Item1 == vydalutyNazva);

var novyiKortezh1 = ("НСК Олімпійський", "Київ, центр", 75000, new string[] { "Футбол", "Легка атлетика", "Концерти" });
var novyiKortezh2 = ("Україна", "Львів, центр", 35000, new string[] { "Футбол", "Концерти" });
stadionyKortezh.Insert(2, novyiKortezh1);
stadionyKortezh.Insert(3, novyiKortezh2);

Console.WriteLine($"\nПісля видалення '{vydalutyNazva}' та додавання 2 елементів після індексу 2:");
foreach (var s in stadionyKortezh)
{
    Console.WriteLine($"Стадіон: {s.Item1}, Адреса: {s.Item2}, Місткість: {s.Item3}, Види спорту: {string.Join(", ", s.Item4)}");
}

Console.WriteLine("\n--- Варіант 3: Записи ---");

Stadion_Zapys[] stadionyZapys = new Stadion_Zapys[]
{
    new Stadion_Zapys("Олімпійський", "Київ, вул. Велика Васильківська", 70050, new string[] { "Футбол", "Легка атлетика" }),
    new Stadion_Zapys("Арена Львів", "Львів, вул. Стрийська", 34915, new string[] { "Футбол" }),
    new Stadion_Zapys("Металіст", "Харків, вул. Клочківська", 40003, new string[] { "Футбол", "Регбі" }),
    new Stadion_Zapys("Чорноморець", "Одеса, вул. Канатна", 34164, new string[] { "Футбол" }),
    new Stadion_Zapys("Дніпро-Арена", "Дніпро, вул. Старокозацька", 31003, new string[] { "Футбол", "Концерти" })
};

Console.WriteLine("Початковий масив записів:");
foreach (var s in stadionyZapys)
{
    s.Show();
}

var spysokZapys = new List<Stadion_Zapys>(stadionyZapys);
spysokZapys.RemoveAll(s => s.Nazva == vydalutyNazva);

var novyiZapys1 = new Stadion_Zapys("НСК Олімпійський", "Київ, центр", 75000, new string[] { "Футбол", "Легка атлетика", "Концерти" });
var novyiZapys2 = new Stadion_Zapys("Україна", "Львів, центр", 35000, new string[] { "Футбол", "Концерти" });
spysokZapys.Insert(2, novyiZapys1);
spysokZapys.Insert(3, novyiZapys2);

stadionyZapys = spysokZapys.ToArray();

Console.WriteLine($"\nПісля видалення '{vydalutyNazva}' та додавання 2 елементів після індексу 2:");
foreach (var s in stadionyZapys)
{
    s.Show();
}

Console.WriteLine("\n=== Лабораторна робота №5 завершена ===");

abstract class Tvarina
{
    protected string nazva;
    protected int vik;
    protected double vaha;

    public Tvarina()
    {
        nazva = "Невідома";
        vik = 0;
        vaha = 0;
        Console.WriteLine("Конструктор Тварина (за замовчуванням)");
    }

    public Tvarina(string nazva)
    {
        this.nazva = nazva;
        vik = 0;
        vaha = 0;
        Console.WriteLine("Конструктор Тварина (назва)");
    }

    public Tvarina(string nazva, int vik, double vaha)
    {
        this.nazva = nazva;
        this.vik = vik;
        this.vaha = vaha;
        Console.WriteLine("Конструктор Тварина (повний)");
    }

    ~Tvarina()
    {
        Console.WriteLine($"Деструктор Тварина: {nazva}");
    }

    public virtual void Show()
    {
        Console.WriteLine($"Тварина: {nazva}, Вік: {vik}, Вага: {vaha} кг");
    }

    public abstract double ObchyslytyShvydkist();
}

class Savets : Tvarina
{
    protected bool maieKhutro;

    public Savets() : base()
    {
        maieKhutro = true;
        Console.WriteLine("Конструктор Савець (за замовчуванням)");
    }

    public Savets(string nazva) : base(nazva)
    {
        maieKhutro = true;
        Console.WriteLine("Конструктор Савець (назва)");
    }

    public Savets(string nazva, int vik, double vaha, bool maieKhutro) : base(nazva, vik, vaha)
    {
        this.maieKhutro = maieKhutro;
        Console.WriteLine("Конструктор Савець (повний)");
    }

    ~Savets()
    {
        Console.WriteLine($"Деструктор Савець: {nazva}");
    }

    public override void Show()
    {
        Console.WriteLine($"Савець: {nazva}, Вік: {vik}, Вага: {vaha} кг, Хутро: {maieKhutro}");
    }

    public override double ObchyslytyShvydkist()
    {
        return vaha * 0.5;
    }
}

class Parnokopytne : Savets
{
    protected int kilkistKopyt;

    public Parnokopytne() : base()
    {
        kilkistKopyt = 4;
        Console.WriteLine("Конструктор Парнокопитне (за замовчуванням)");
    }

    public Parnokopytne(string nazva) : base(nazva)
    {
        kilkistKopyt = 4;
        Console.WriteLine("Конструктор Парнокопитне (назва)");
    }

    public Parnokopytne(string nazva, int vik, double vaha, bool maieKhutro, int kilkistKopyt) : base(nazva, vik, vaha, maieKhutro)
    {
        this.kilkistKopyt = kilkistKopyt;
        Console.WriteLine("Конструктор Парнокопитне (повний)");
    }

    ~Parnokopytne()
    {
        Console.WriteLine($"Деструктор Парнокопитне: {nazva}");
    }

    public override void Show()
    {
        Console.WriteLine($"Парнокопитне: {nazva}, Вік: {vik}, Вага: {vaha} кг, Хутро: {maieKhutro}, Копита: {kilkistKopyt}");
    }

    public override double ObchyslytyShvydkist()
    {
        return vaha * 0.8;
    }
}

class Ptakh : Tvarina
{
    protected bool mozheLitaty;
    protected int rozmakhKryl;

    public Ptakh() : base()
    {
        mozheLitaty = true;
        rozmakhKryl = 0;
        Console.WriteLine("Конструктор Птах (за замовчуванням)");
    }

    public Ptakh(string nazva) : base(nazva)
    {
        mozheLitaty = true;
        rozmakhKryl = 0;
        Console.WriteLine("Конструктор Птах (назва)");
    }

    public Ptakh(string nazva, int vik, double vaha, bool mozheLitaty, int rozmakhKryl) : base(nazva, vik, vaha)
    {
        this.mozheLitaty = mozheLitaty;
        this.rozmakhKryl = rozmakhKryl;
        Console.WriteLine("Конструктор Птах (повний)");
    }

    ~Ptakh()
    {
        Console.WriteLine($"Деструктор Птах: {nazva}");
    }

    public override void Show()
    {
        Console.WriteLine($"Птах: {nazva}, Вік: {vik}, Вага: {vaha} кг, Літає: {mozheLitaty}, Розмах крил: {rozmakhKryl} см");
    }

    public override double ObchyslytyShvydkist()
    {
        return rozmakhKryl * 0.3;
    }
}

abstract class Trans
{
    protected string marka;
    protected string nomer;
    protected int shvydkist;
    protected double vantazhopidiomnist;

    public Trans()
    {
        marka = "Невідома";
        nomer = "0000";
        shvydkist = 0;
        vantazhopidiomnist = 0;
    }

    public Trans(string marka, string nomer, int shvydkist, double vantazhopidiomnist)
    {
        this.marka = marka;
        this.nomer = nomer;
        this.shvydkist = shvydkist;
        this.vantazhopidiomnist = vantazhopidiomnist;
    }

    public virtual void Show()
    {
        Console.WriteLine($"Транспорт: {marka}, Номер: {nomer}, Швидкість: {shvydkist} км/год, Вантажопідйомність: {vantazhopidiomnist} кг");
    }

    public abstract double OtrymatyVantazhopidiomnist();
}

class Lehkova_mashyna : Trans
{
    public Lehkova_mashyna() : base() { }

    public Lehkova_mashyna(string marka, string nomer, int shvydkist, double vantazhopidiomnist)
        : base(marka, nomer, shvydkist, vantazhopidiomnist) { }

    public override void Show()
    {
        Console.WriteLine($"Легкова машина: {marka}, Номер: {nomer}, Швидкість: {shvydkist} км/год, Вантажопідйомність: {vantazhopidiomnist} кг");
    }

    public override double OtrymatyVantazhopidiomnist()
    {
        return vantazhopidiomnist;
    }
}

class Mototsykl : Trans
{
    protected bool naiavnistKoliasky;

    public Mototsykl() : base()
    {
        naiavnistKoliasky = false;
    }

    public Mototsykl(string marka, string nomer, int shvydkist, double vantazhopidiomnist, bool naiavnistKoliasky)
        : base(marka, nomer, shvydkist, vantazhopidiomnist)
    {
        this.naiavnistKoliasky = naiavnistKoliasky;
        if (!naiavnistKoliasky)
        {
            this.vantazhopidiomnist = 0;
        }
    }

    public override void Show()
    {
        Console.WriteLine($"Мотоцикл: {marka}, Номер: {nomer}, Швидкість: {shvydkist} км/год, Вантажопідйомність: {vantazhopidiomnist} кг, Коляска: {naiavnistKoliasky}");
    }

    public override double OtrymatyVantazhopidiomnist()
    {
        if (!naiavnistKoliasky)
            return 0;
        return vantazhopidiomnist;
    }
}

class Vantazhivka : Trans
{
    protected bool naiavnistPrichepa;

    public Vantazhivka() : base()
    {
        naiavnistPrichepa = false;
    }

    public Vantazhivka(string marka, string nomer, int shvydkist, double vantazhopidiomnist, bool naiavnistPrichepa)
        : base(marka, nomer, shvydkist, vantazhopidiomnist)
    {
        this.naiavnistPrichepa = naiavnistPrichepa;
        if (naiavnistPrichepa)
        {
            this.vantazhopidiomnist *= 2;
        }
    }

    public override void Show()
    {
        Console.WriteLine($"Вантажівка: {marka}, Номер: {nomer}, Швидкість: {shvydkist} км/год, Вантажопідйомність: {vantazhopidiomnist} кг, Причіп: {naiavnistPrichepa}");
    }

    public override double OtrymatyVantazhopidiomnist()
    {
        if (naiavnistPrichepa)
            return vantazhopidiomnist * 2;
        return vantazhopidiomnist;
    }
}

struct Stadion_Struktura
{
    public string Nazva;
    public string Adresa;
    public int Mistkist;
    public string[] VydSportu;

    public Stadion_Struktura(string nazva, string adresa, int mistkist, string[] vydSportu)
    {
        Nazva = nazva;
        Adresa = adresa;
        Mistkist = mistkist;
        VydSportu = vydSportu;
    }

    public void Show()
    {
        Console.WriteLine($"Стадіон: {Nazva}, Адреса: {Adresa}, Місткість: {Mistkist}, Види спорту: {string.Join(", ", VydSportu)}");
    }
}

record Stadion_Zapys(string Nazva, string Adresa, int Mistkist, string[] VydSportu)
{
    public void Show()
    {
        Console.WriteLine($"Стадіон: {Nazva}, Адреса: {Adresa}, Місткість: {Mistkist}, Види спорту: {string.Join(", ", VydSportu)}");
    }
}
