﻿namespace RecipeBook.Data.Repositories;

using Context;

public interface IRepository<T> where T : class, IEntity
{
    List<T>? GetAll();
    T? Get(long id);
    T? Add(T entity);
    T? Update(T entity);
    T? Delete(long id);
}
