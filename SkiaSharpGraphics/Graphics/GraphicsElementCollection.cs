using System.Collections;
using System.Collections.Generic;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace SkiaSharpGraphics.Graphics
{
	public class GraphicsElementCollection : IList<GraphicsElement>, IEnumerable<GraphicsElement>
	{
		private readonly List<GraphicsElement> items;
		private readonly IGraphicsElementContainer container;

		public GraphicsElementCollection(IGraphicsElementContainer elementContainer)
		{
			items = new List<GraphicsElement>();
			container = elementContainer;
		}

		public int Count => items.Count;

		public bool IsReadOnly => false;

		public bool Contains(GraphicsElement item) => items.Contains(item);

		public void CopyTo(GraphicsElement[] array, int arrayIndex) => items.CopyTo(array, arrayIndex);

		public IEnumerator<GraphicsElement> GetEnumerator() => items.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();

		public int IndexOf(GraphicsElement item) => items.IndexOf(item);

		public GraphicsElement this[int index]
		{
			get => items[index];
			set
			{
				OnChildRemoved(items[index]);

				items[index] = value;

				OnChildAdded(value);
			}
		}

		public void Add(GraphicsElement item)
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

		public void Insert(int index, GraphicsElement item)
		{
			items.Insert(index, item);

			OnChildAdded(item);
		}

		public bool Remove(GraphicsElement item)
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

		private void OnChildAdded(GraphicsElement element)
		{
			if (element != null)
			{
				if (element.Parent is IGraphicsElementContainer oldContainer)
				{
					oldContainer.Children.Remove(element);
				}
				if (container is Element containerElement)
				{
					element.Parent = containerElement;
				}
			}
		}

		private void OnChildRemoved(GraphicsElement element)
		{
			if (element != null)
			{
				element.Parent = null;
			}
		}
	}
}
