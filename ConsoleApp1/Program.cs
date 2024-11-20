using System;



public class Network
{
    private int[] sire;

    public Network(int n)
    {
        if (n <= 0)
        {

            throw new ArgumentException("O numero deve ser positivo");
        }

        sire = new int[n];

        for (int i = 0; i < n; i++) {
            sire[i] = i;

        }
    }
        public int Find(int x) {
        ValidateElement(x);
        

        while(sire[x] != x)
        {
            x = sire[x];
        }


        return x;
              
    }


    public void Connect(int elemento1, int elemento2)
    {
        ValidateElement(elemento1);
        ValidateElement(elemento2);

        int root1 = Find(elemento1);
        int root2 = Find(elemento2);
        if (root1 != root2)
        {
            sire[root2] = root1;
        }
    }



    public bool Query(int element1, int element2)
    {
        ValidateElement(element1);
        ValidateElement(element2);

        return Find(element1) == Find(element2);
    }


    public void ValidateElement(int x)
    {


        if (x <= 0 || x > sire.Length)
        {
            throw new ArgumentException("vai retornar sytemoutindex, o numero é maior que a array");
        }
    }
}

// com base no algoritimo union-find encontrado no site da ime-usp

public class Program
{



    public static void Main(string[] args)
    {

        Network net = new Network(8);

        net.Connect(1, 2);
        net.Connect(6, 2);

        bool conectado = net.Query(2, 6);

        Console.WriteLine(conectado);
    }
}