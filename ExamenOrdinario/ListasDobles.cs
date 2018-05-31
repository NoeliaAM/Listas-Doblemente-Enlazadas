using System;

class Nodo<T>
{
    public T Info;
    public Nodo<T> Next;
    public Nodo<T> Ante;

    public Nodo() { }
};

public interface IFunction<T>
{
    bool Same(T a, T b);
}

class ListaD<T>
{
    Nodo<T> First;
    Nodo<T> Last;
    Nodo<T> Current;
    Nodo<T> Previo;
    Int64 Total;

    public IFunction<T> Comparar;

    public ListaD()
    {
        this.First = null;
        this.Last = null;
        this.Current = null;
        this.Previo = null;
    }

    public void Vaciar()
    {
        this.First = null; this.Last = null; this.Current = null; this.Previo = null;
    }

    public void Add(T Data)
    {
        Nodo<T> Temp;
        Temp = new Nodo<T>();
        Temp.Info = Data;

        if (this.isEmpty())
        {
            Temp.Next = null; Temp.Ante = null;
            this.Last = this.First = this.Current = Temp;
        }
        else
        {
            Temp.Next = null;
            Temp.Ante = Last;
            this.Last.Next = Temp;
            this.Last = Temp;
        }
        Total++;
    }

    public void AddFirst(T Data)
    {
        if (!this.isEmpty())
        {
            Nodo<T> temp;
            temp = new Nodo<T>();
            temp.Info = Data;
            temp.Next = this.First;
            temp.Ante = null;
            this.First = temp;
        }
    }

    public void AddAfter(T ante, T Data)
    {
        Nodo<T> temp;
        if (this.Find(ante, Comparar))
        {
            temp = new Nodo<T>();
            temp.Info = Data;
            temp.Next = Current.Next;
            temp.Ante = Current;
            this.Current.Next = temp;
        }
    }

    public bool Find(T Data, IFunction<T> equal)
    {
        bool Found = false;
        this.MoveFirst();

        while (!Found && this.Current != null)
        {
            if (equal.Same(this.getInfo(), Data))
            {
                Found = true;
            }
            else
            {
                this.MoveNext();
            }
        }
        if (!Found)
        {
            this.MoveLast();
        }
        return Found;
    }

    public bool isEmpty()
    {
        return (this.First == null);
    }

    public void New()
    {
        this.First = null;
    }

    public bool isFirst()
    {
        return this.First == Current;
    }

    public bool isLast()
    {
        return this.Last == Current;
    }

    public void MoveFirst()
    {
        this.Previo = null;
        this.Current = this.First;
    }

    public void MoveLast()
    {
        this.Current = this.Last;
    }

    public void MoveNext()
    {
        if (this.Current != null)
        {
            this.Previo = Current;
            this.Current = this.Current.Next;
        }
    }

    public void MoveAnte()
    {
        if (this.Previo != null)
        {
            this.Current = Previo;
            this.Previo = this.Previo.Ante;
        }
    }

    public T getInfo()
    {
        return this.Current.Info;
    }

    public bool Delete(T Data)
    {
        bool retVal = false;

        if (this.Find(Data, Comparar))
        {
            if (this.isFirst() && this.Previo == null)
            {
                this.First = this.First.Next;
                this.Current = this.First;
            }

            else
            {
                if (this.isLast())
                {
                    this.Previo.Next = null;
                    this.Last = this.Previo;
                    this.Current = this.Last;
                    this.MoveLast();
                }
                else
                {
                    this.Previo.Next = this.Current.Next;
                    this.Current = this.Previo.Next;
                }
            }
            retVal = true;
        }
        return retVal;
    }

    public Int64 Size()
    {
        return this.Total;
    }

}