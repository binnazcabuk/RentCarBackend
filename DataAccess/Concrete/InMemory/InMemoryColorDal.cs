using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryColorDal : IColorDal
    {
        List<Color> _colors;

        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {
                new Color {ColorId = 1, Name = "Beyaz"},
                new Color {ColorId = 2, Name = "Mavi"},
                new Color {ColorId = 3, Name = "Kirmizi"},
                new Color {ColorId = 4, Name = "Gri"},
                new Color {ColorId = 5, Name = "Siyah"},
            };
        }
        public void Add(Color color)
        {
            _colors.Add(color);
        }

        public void Delete(Color color)
        {
            var colorToDelete = _colors.SingleOrDefault(c => c.ColorId == color.ColorId);
            _colors.Remove(colorToDelete);
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAll()
        {
            return _colors;
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Color GetById(int id)
        {
            return _colors.SingleOrDefault(c => c.ColorId == id);
        }

        public void Update(Color color)
        {
            var colorToUpdate = _colors.SingleOrDefault(c => c.ColorId == color.ColorId);

            colorToUpdate.ColorId = color.ColorId;
            colorToUpdate.Name = color.Name;
        }
    }
}
