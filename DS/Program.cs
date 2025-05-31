int[] arr = [1, 4, 8, 6, 3];

int[] arr2 = new int[4000];

arr2[0] = 1;
arr2[1] = 8;
arr2[2] = 0;
arr2[3] = 8656464;

long[] arr3 = new long[4];


var a = arr2[2];
var b = arr2[3016];

List<int> ints = new List<int>();
var u = ints[10000];

bool Contains(int[] ar, int val)
{
    for (int i = 0; i < ar.Length; i++)
    {   
        if (ar[i] == val)
        {
            return true;
        }
    }
    return false;
}

bool Test(int[] ar)
{
    for (int i = 0; i < ar.Length; i++)
    {
        for (int j = i + 1; j < ar.Length; j++)
        {
            if (ar[i] + ar[j] == 10)
            {
                return true;
            }
        }
    }

    return false;
}