using System.Text;

namespace ProjectEuler
{
    internal abstract class BaseProblem
    {
        protected int ProblemNumber;

        protected string OutputTemplate;

        protected long InputParam;

        private long? _solutionValue;

        protected long? SolutionValue
        {
            get { return _solutionValue ?? (_solutionValue = Solve()); }
        }

        protected BaseProblem(int problemNumber, long inputParam, string outputTemplate)
        {
            ProblemNumber = problemNumber;
            InputParam = inputParam;
            OutputTemplate = outputTemplate;
        }

        protected abstract long Solve();

        public StringBuilder SolutionOutput()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Problem {0}:\n", ProblemNumber);
            result.AppendFormat(OutputTemplate, InputParam, SolutionValue);
            return result;
        }
    }
}
