using System.Collections.Generic;

namespace TestedeDados.Data.Converter.Contract
{
    // interface para conversores
    public interface IParser <O,D>
    {
        D Parse(O origin);
        List<D> Parse(List<O> origin);
    }
}
