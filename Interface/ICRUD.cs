namespace Chat_Bot.Interfaces
{
    interface ICRUD<T>
    {
        void AddItem(T t);

        void DeleteItem(T t);

        T GetItem(T t);
    }

    interface ICRUD<T, T1>
    {
        void AddItem(T t, T1 t1);

        void DeleteItem(T t, T1 t1);

        T GetItem(T t, T1 t1);
    }
}
