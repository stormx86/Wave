using System;
using System.Windows.Forms;


namespace Wave
{
    class Logic
    {
        int size = 20;
        int[,] map;
        int Ni, Nmin;
        static int Nk = 30;
        DelegateShow show;
        static Random rand = new Random();
        int start_x, start_y;
        public bool flag, flag2;

        public Logic(int size, DelegateShow show)
        {
            this.size = size;
            map = new int[size, size];
            this.show = show;
            Ni = 0;
            flag = false;
            flag2 = false;
        }

        public void init_game()
        {
            Ni = 0;
            Nmin = 0;
            flag = false;
            flag2 = false;
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                {
                    map[x, y] = rand.Next(254, 256);
                    show(x, y, map[x, y]);
                }
            map[rand.Next(1, 19), rand.Next(1, 19)] = 0;
            map[rand.Next(1, 19), rand.Next(1, 19)] = 253;
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    show(x, y, map[x, y]);
        }

        public void Wave()
        {
            for (int i = 1; i < map.GetLength(0)-1; i++)
                for (int j = 1; j < map.GetLength(1)-1; j++)
                {
                    if (map[i, j] == Ni)
                    {
                        for (int k = -1; k < 2; k++)
                            for (int m = -1; m < 2; m++)

                                if (map[i + k, j + m] == 254) map[i + k, j + m] = Ni + 1;
                                else if (map[i + k, j + m] == 253)
                                {
                                    start_x = i + k;
                                    start_y = j + m;
                                    MessageBox.Show("Starting position was found!");
                                    Nmin = Ni;
                                    flag = true;
                                }
                        if (Ni == Nk)
                        {
                            MessageBox.Show("The shortest path was found!");
                            return;
                        }
                    }
                    show(i, j, map[i, j]);
                }
            Ni++;
        }

       public void lookup_finish()
        {
                for (int k = -1; k < 2; k++)
                    for (int m = -1; m < 2; m++)
                    {
                        if (map[start_x + k, start_y + m] == Nmin && map[start_x + k, start_y + m] != 0)
                        {
                            map[start_x + k, start_y + m] = 251;
                            show(start_x + k, start_y + m, map[start_x + k, start_y + m]);
                            start_x = start_x + k;
                            start_y = start_y + m;
                            Nmin--;
                        }
                    }
                flag2 = true;
           if(Nmin==0 && flag2 == true) MessageBox.Show("The shortest path was found!");
        }

    }

}
 