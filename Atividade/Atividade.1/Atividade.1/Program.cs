using Atividade;


// Atividade 1.1 - Desenvolva uma aplicação que descubra qual o número inicial entre 1 e 1 milhão que produz a maior sequência.

long numeroInicial = 0;
int maxTamanho = 0;

for (long i = 1; i <= 1000000; i++)
{
    int tamanho = CalculoSequenciaCollatz.ObterSequenciaCollatz(i);

    if (tamanho > maxTamanho)
    {
        maxTamanho = tamanho;
        numeroInicial = i;
    }
}

Console.WriteLine($"Atividade 1.1");
Console.WriteLine($"O número inicial com a maior sequência é {numeroInicial} com {maxTamanho} termos.");
Console.Write("\n");


//Atividade 1.2 Elabore um método que defina se o seguinte array contém somente números ímpares e demonstre o resultado no console

int[] numeros = { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };

var resultadoAtv1_2 = numeros.All(n => n % 2 != 0);

Console.WriteLine($"Atividade 1.2");
Console.WriteLine($"{(resultadoAtv1_2 ? "Todos são ímpares" : "Nem todos são ímpares")}");
Console.Write("\n");





//Atividade 1.2 - Elabore um método que traga somente os números do primeiro array que não estejam contidos no segundo array e demonstre o resultado no console

int[] primeiroArray = { 1, 3, 7, 29, 42, 98, 234, 93 };
int[] segundoArray = { 4, 6, 93, 7, 55, 32, 3 };

var resultadoAtv1_3 = primeiroArray.Except(segundoArray).ToArray();

Console.WriteLine($"Atividade 1.3");
foreach (var item in resultadoAtv1_3)
{
    Console.Write($"{item} ");
}