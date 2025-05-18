namespace Game
{
    internal static class UIManager
    {
        public static void VisualizationRound(StepType playerStep, StepType pcStep)
        {
            if (playerStep == StepType.Rock && pcStep == StepType.Rock)
            {
                Console.WriteLine("    _______                _______    ");
                Console.WriteLine("---'   ____)              (____   '---");
                Console.WriteLine("      (_____)            (_____)      ");
                Console.WriteLine("      (_____)            (_____)      ");
                Console.WriteLine("      (____)              (____)      ");
                Console.WriteLine("---.__(___)                (___)__.---");
            }
            else if(playerStep == StepType.Scissors && pcStep == StepType.Scissors)
            {
                Console.WriteLine("    _______                _______    ");
                Console.WriteLine("---'   ____)___        ___(____   '---");
                Console.WriteLine("       ________)      (________       ");
                Console.WriteLine("       _________)    (_________       ");
                Console.WriteLine("      (____)              (____)      ");
                Console.WriteLine("---.__(___)                (___)__.---");
            }
            else if (playerStep == StepType.Paper && pcStep == StepType.Paper)
            {
                Console.WriteLine("    _______                _______    ");
                Console.WriteLine("---'   ____)___        ___(____   '---");
                Console.WriteLine("       ________)      (________       ");
                Console.WriteLine("       _________)    (_________       ");
                Console.WriteLine("       ________)      (________       ");
                Console.WriteLine("---._________)          (_________.---");
            }

            else if(playerStep == StepType.Rock && pcStep == StepType.Scissors)
            {
                Console.WriteLine("    _______                _______    ");
                Console.WriteLine("---'   ____)           ___(____   '---");
                Console.WriteLine("      (_____)         (________       ");
                Console.WriteLine("      (_____)        (_________       ");
                Console.WriteLine("      (____)              (____)      ");
                Console.WriteLine("---.__(___)                (___)__.---");
            }
            else if (playerStep == StepType.Rock && pcStep == StepType.Paper)
            {
                Console.WriteLine("    _______                _______    ");
                Console.WriteLine("---'   ____)           ___(____   '---");
                Console.WriteLine("      (_____)         (________       ");
                Console.WriteLine("      (_____)        (_________       ");
                Console.WriteLine("      (____)          (________       ");
                Console.WriteLine("---.__(___)             (_________.---");
            }

            else if (playerStep == StepType.Scissors && pcStep == StepType.Rock)
            {
                Console.WriteLine("    _______                _______    ");
                Console.WriteLine("---'   ____)___           (____   '---");
                Console.WriteLine("       ________)         (_____)      ");
                Console.WriteLine("       _________)        (_____)      ");
                Console.WriteLine("      (____)              (____)      ");
                Console.WriteLine("---.__(___)                (___)__.---");
            }
            else if (playerStep == StepType.Scissors && pcStep == StepType.Paper)
            {
                Console.WriteLine("    _______                _______    ");
                Console.WriteLine("---'   ____)___        ___(____   '---");
                Console.WriteLine("       ________)      (________       ");
                Console.WriteLine("       _________)    (_________       ");
                Console.WriteLine("      (____)          (________       ");
                Console.WriteLine("---.__(___)             (_________.---");
            }
            
            else if (playerStep == StepType.Paper && pcStep == StepType.Rock)
            {
                Console.WriteLine("    _______                _______    ");
                Console.WriteLine("---'   ____)___           (____   '---");
                Console.WriteLine("       ________)         (_____)      ");
                Console.WriteLine("       _________)        (_____)      ");
                Console.WriteLine("       ________)          (____)      ");
                Console.WriteLine("---._________)             (___)__.---");
            }
            else if (playerStep == StepType.Paper && pcStep == StepType.Scissors)
            {
                Console.WriteLine("    _______                _______    ");
                Console.WriteLine("---'   ____)___        ___(____   '---");
                Console.WriteLine("       ________)      (________       ");
                Console.WriteLine("       _________)    (_________       ");
                Console.WriteLine("       ________)          (____)      ");
                Console.WriteLine("---._________)             (___)__.---");
            }
        }
    }
}
