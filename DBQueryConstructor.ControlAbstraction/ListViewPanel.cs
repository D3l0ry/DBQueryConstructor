﻿namespace DBQueryConstructor.ControlAbstraction;

/// <summary>
/// Панель с массивом объектов выбранного наследника типа Control
/// Тип лучше указывать, который наследуется от ViewGroupBox
/// </summary>
/// <remarks>Тип лучше указывать, который наследуется от ViewGroupBox</remarks>
/// <typeparam name="PanelType"></typeparam>
public abstract class ListViewPanel<PanelType> : TableLayoutPanel where PanelType : GroupBox
{
    public ListViewPanel() : base() { }

    public IEnumerable<PanelType> Panels => Controls.OfType<PanelType>();

    public event EventHandler DataChanged;

    public virtual void OnDataChanged() => DataChanged?.Invoke(this, EventArgs.Empty);

    public virtual void AddPanel(PanelType panel)
    {
        if (panel == null)
        {
            throw new ArgumentNullException(nameof(panel));
        }

        Controls.Add(panel);
    }
}