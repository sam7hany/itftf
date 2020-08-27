using System;

public class ProgressBar
{
    private int _lastOutputLength;
    private readonly int _maximumWidth;

    public ProgressBar(int maximumWidth)
    {
        _maximumWidth = maximumWidth;
        Show(" [ ");
    }

    public void Update(double percent)
    {
        // Remove the last state           
        string clear = string.Empty.PadRight(_lastOutputLength, '\b');

        Show(clear);

        // Generate new state           
        int width = (int)(percent / 100 * _maximumWidth);
        int fill = _maximumWidth - width;
        string output = string.Format("{0}{1} ] {2}%", string.Empty.PadLeft(width, '■'), string.Empty.PadLeft(fill, ' '), percent.ToString("0.0"));
        Show(output);
        _lastOutputLength = output.Length;
    }

    private void Show(string value)
    {
        Console.SetCursorPosition((Console.WindowWidth - value.Length) / 2, Console.CursorTop);

        Console.Write(value);
    }
}