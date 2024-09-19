using System.Collections;

namespace SkiaSharpGraphics.Graphics;

public class GraphicsOperationCollection : IList<GraphicsOperation>, IEnumerable<GraphicsOperation>
{
    private readonly List<GraphicsOperation> items;
    private readonly IGraphicsOperationContainer container;

    public GraphicsOperationCollection(IGraphicsOperationContainer elementContainer)
    {
        items = new List<GraphicsOperation>();
        container = elementContainer;
    }

    public int Count => items.Count;

    public bool IsReadOnly => false;

    public bool Contains(GraphicsOperation item) => items.Contains(item);

    public void CopyTo(GraphicsOperation[] array, int arrayIndex) => items.CopyTo(array, arrayIndex);

    public IEnumerator<GraphicsOperation> GetEnumerator() => items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();

    public int IndexOf(GraphicsOperation item) => items.IndexOf(item);

    public GraphicsOperation this[int index]
    {
        get => items[index];
        set
        {
            OnChildRemoved(items[index]);

            items[index] = value;

            OnChildAdded(value);
        }
    }

    public void Add(GraphicsOperation item)
    {
        items.Add(item);

        OnChildAdded(item);
    }

    public void Clear()
    {
        var temp = items.ToArray();
        foreach (var t in temp)
        {
            OnChildRemoved(t);
        }

        items.Clear();
    }

    public void Insert(int index, GraphicsOperation item)
    {
        items.Insert(index, item);

        OnChildAdded(item);
    }

    public bool Remove(GraphicsOperation item)
    {
        var result = items.Remove(item);
        if (result)
        {
            OnChildRemoved(item);
        }
        return result;
    }

    public void RemoveAt(int index)
    {
        OnChildRemoved(items[index]);

        items.RemoveAt(index);
    }

    private void OnChildAdded(GraphicsOperation element)
    {
        if (element != null)
        {
            if (element.Parent is IGraphicsOperationContainer oldContainer)
            {
                oldContainer.Operations.Remove(element);
            }
            if (container is Element containerElement)
            {
                element.Parent = containerElement;
            }
        }
    }

    private void OnChildRemoved(GraphicsOperation element)
    {
        if (element != null)
        {
            element.Parent = null;
        }
    }
}
