//DemoForLoop();
//DemoWhileLoop();
//DemoDoWhileLoop();
DemoForEachLoop();

static void DemoForLoop()
{
    for(int i = 1; i <= 10; i+=2)
    {
        Console.WriteLine($"i: {i}");
    }

    for(int i = 10; i > 0; i--)
    {
        Console.WriteLine($"i: {i}");
    }
}

static void DemoWhileLoop()
{
    int i=1;
    while (i<=5)
    {
        Console.WriteLine(i);
        i++;
    }
}

static void DemoDoWhileLoop()
{
    int i=1;
    do
    {
        Console.WriteLine(i);
        i++;
    } while (i<=5);
}

static void DemoForEachLoop()
{
    int[] arr=new int[]{10, 20, 30, 40, 50};

    int sum=0;

    foreach (int number in arr)
    {
        sum+=number;
    }   

    Console.WriteLine($"The sum is: {sum}"); 
}

