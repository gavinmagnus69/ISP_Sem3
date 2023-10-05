﻿namespace Lab6;

public interface IFileService<T>
{
    IEnumerable<T> ReadFile(string fileName);
    void SaveData(IEnumerable<T> data, string fileName);
    
}