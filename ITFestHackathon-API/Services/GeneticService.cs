using HealthIQ.Services;

namespace HealthIQ
{
    public class WorkoutExercises
    {
        public string Name { get; set; } 
        public string Difficulty { get; set; } 
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int RestBetweenSets { get; set; }
    }
    public class Workout
    {
        public string Day { get; set; }
        public List<WorkoutExercises> Exercises { get; set; }
    }
    public class Exercise
    {
        public string Name { get; }
        public string Difficulty { get; }
        public string PrimaryGroup { get; }
        public string SecondaryGroup { get; }

        public Exercise(string name, string difficulty, string primaryGroup, string secondaryGroup)
        {
            Name = name;
            Difficulty = difficulty;
            PrimaryGroup = primaryGroup;
            SecondaryGroup = secondaryGroup;
        }
    }

    public class User
    {
        public int Height { get; }
        public int Weight { get; }
        public string Gender { get; }
        public int TrainingFrequency { get; }
        public DateTime BirthDate { get; }
        public string FitLevel { get; }

        public User(int height, int weight, string gender, int trainingFrequency, DateTime birthDate, string fitLevel)
        {
            Height = height;
            Weight = weight;
            Gender = gender;
            TrainingFrequency = trainingFrequency;
            BirthDate = birthDate;
            FitLevel = fitLevel;
        }
    }
    public class GeneticService : IGeneticService
    {
        public List<Workout> GenerateWorkoutPlan()
        {
            ExerciseList List = new ExerciseList();
            string exerciseList = List.GetExerciseList();

            var user = new User(172, 52, "Female", 4, new DateTime(1990, 1, 1), "Intermediate");
            int populationSize = 100;
            int numGenerations = 50;
            var sets = 3;
            var reps = 12;
            var restBetweenSets = 3;
            List<Workout> workouts = new List<Workout>();
            var bestWorkoutPlan = GenerateWorkoutPlan(user, exerciseList, populationSize, numGenerations);

            for (int day = 0; day < bestWorkoutPlan.Count; day++)
            {
                List<WorkoutExercises> workoutsExerices = new List<WorkoutExercises>();

                foreach (var exerciseIndex in bestWorkoutPlan[day])
                {
                    var exercise = ParseExerciseList(exerciseList)[exerciseIndex];
                    workoutsExerices.Add(new WorkoutExercises { Name = exercise.Name, Difficulty = exercise.Difficulty,Sets=sets,Reps=reps,RestBetweenSets=restBetweenSets });
                }

                workouts.Add(new Workout { Day = $"Day {day + 1}", Exercises = workoutsExerices });
            }

            return workouts;

        }



        static List<Exercise> ParseExerciseList(string exerciseList)
            {
                var exercises = new List<Exercise>();
                foreach (var exerciseInfo in exerciseList.Split('\n'))
                {
                    if (!string.IsNullOrWhiteSpace(exerciseInfo))
                    {
                        var exerciseData = exerciseInfo.Split();
                        var name = exerciseData[0];
                        var difficulty = exerciseData[1];
                        var primaryGroup = exerciseData[2];
                        var secondaryGroup = exerciseData[3];
                        exercises.Add(new Exercise(name, difficulty, primaryGroup, secondaryGroup));
                    }
                }
                return exercises;
            }

        
        static List<List<List<int>>> InitializePopulation(int populationSize, int numExercises, int trainingFrequency)
        {
            var population = new List<List<List<int>>>();
            var random = new Random();

            for (int i = 0; i < populationSize; i++)
            {
                var workoutPlan = new List<List<int>>();
                for (int j = 0; j < trainingFrequency; j++)
                {
                    var dayPlan = new List<int>();
                    int exercisesCount = random.Next(4, 9);
                    while (dayPlan.Count < exercisesCount)
                    {
                        int exerciseIndex = random.Next(0, numExercises);
                        if (!dayPlan.Contains(exerciseIndex))
                        {
                            dayPlan.Add(exerciseIndex);
                        }
                    }
                    workoutPlan.Add(dayPlan);
                }
                population.Add(workoutPlan);
            }
            return population;
        }

        static int FitnessFunction(List<List<int>> workoutPlan, User user, List<Exercise> exercises)
        {
            double score = 0;

            for (int dayIndex = 0; dayIndex < workoutPlan.Count; dayIndex++)
            {
                var day = workoutPlan[dayIndex];
                var primaryGroups = new HashSet<string>();
                var secondaryGroups = new HashSet<string>();

                int exerciseCount = day.Count;
                if (4 <= exerciseCount && exerciseCount <= 8)
                {
                    score++;
                }

                foreach (var exerciseIndex in day)
                {
                    var exercise = exercises[exerciseIndex];
                    primaryGroups.Add(exercise.PrimaryGroup);
                    secondaryGroups.Add(exercise.SecondaryGroup);

                    if (user.FitLevel == exercise.Difficulty)
                    {
                        score++;
                    }
                    else if (user.FitLevel == "Beginner" && exercise.Difficulty == "Intermediate")
                    {
                        score += 0.5;
                    }
                    else if (user.FitLevel == "Intermediate" && exercise.Difficulty == "Advanced")
                    {
                        score += 0.5;
                    }

                    if (user.Gender == "Female" && new List<string> { "Quadriceps", "Glutes", "Hamstrings", "Calves" }.Contains(exercise.PrimaryGroup))
                    {
                        score++;
                    }
                }

                if (primaryGroups.Count <= 3)
                {
                    score++;
                }

                if (primaryGroups.Count >= 2 && secondaryGroups.Count >= 2)
                {
                    score++;
                }

                if (dayIndex > 0)
                {
                    var prevDayPrimaryGroups = workoutPlan[dayIndex - 1].Select(exerciseIndex => exercises[exerciseIndex].PrimaryGroup).ToHashSet();
                    var prevDaySecondaryGroups = workoutPlan[dayIndex - 1].Select(exerciseIndex => exercises[exerciseIndex].SecondaryGroup).ToHashSet();

                    if (primaryGroups.Intersect(prevDayPrimaryGroups).Any() || secondaryGroups.Intersect(prevDaySecondaryGroups).Any())
                    {
                        score--;
                    }
                }

                int compoundExercises = day.Count(exerciseIndex => !string.IsNullOrEmpty(exercises[exerciseIndex].SecondaryGroup));
                int isolationExercises = exerciseCount - compoundExercises;
                if (compoundExercises >= 1 && isolationExercises >= 1)
                {
                    score++;
                }

                int age = DateTime.Now.Year - user.BirthDate.Year;
                if (age < 30)
                {
                    if (exerciseCount >= 6)
                    {
                        score++;
                    }
                }
                else if (age >= 30 && age < 50)
                {
                    if (5 <= exerciseCount && exerciseCount <= 7)
                    {
                        score++;
                    }
                }
                else
                {
                    if (4 <= exerciseCount && exerciseCount <= 6)
                    {
                        score++;
                    }
                }
            }

            return (int)score;
        }

        static List<List<List<int>>> Selection(List<List<List<int>>> population, List<int> fitnessScores)
        {
            var selectedParents = new List<List<List<int>>>();
            var random = new Random();

            for (int i = 0; i < population.Count; i++)
            {
                int parentIndex1 = random.Next(fitnessScores.Count);
                int parentIndex2 = random.Next(fitnessScores.Count);

                if (fitnessScores[parentIndex1] > fitnessScores[parentIndex2])
                {
                    selectedParents.Add(population[parentIndex1]);
                }
                else
                {
                    selectedParents.Add(population[parentIndex2]);
                }
            }

            return selectedParents;
        }

        static List<List<List<int>>> Crossover(List<List<List<int>>> parents)
        {
            var offspring = new List<List<List<int>>>();
            var random = new Random();

            for (int i = 0; i < parents.Count - 1; i += 2)
            {
                var parent1 = parents[i];
                var parent2 = parents[i + 1];
                int crossoverPoint = random.Next(1, parent1.Count - 1);

                var child1 = parent1.Take(crossoverPoint).Concat(parent2.Skip(crossoverPoint)).ToList();
                var child2 = parent2.Take(crossoverPoint).Concat(parent1.Skip(crossoverPoint)).ToList();

                offspring.Add(child1);
                offspring.Add(child2);
            }

            return offspring;
        }

        static List<List<List<int>>> Mutation(List<List<List<int>>> offspring, int numExercises)
        {
            var random = new Random();

            foreach (var workoutPlan in offspring)
            {
                foreach (var dayPlan in workoutPlan)
                {
                    if (random.NextDouble() < 0.1)
                    {
                        int mutationIndex = random.Next(dayPlan.Count);
                        dayPlan[mutationIndex] = random.Next(numExercises);
                    }
                }
            }

            return offspring;
        }

        static List<List<int>> GenerateWorkoutPlan(User user, string exerciseList, int populationSize, int numGenerations )
        {
            var exercises = ParseExerciseList(exerciseList);
            var population = InitializePopulation(populationSize, exercises.Count, user.TrainingFrequency);

            for (int generation = 0; generation < numGenerations; generation++)
            {
                var fitnessScores = population.Select(workoutPlan => FitnessFunction(workoutPlan, user, exercises)).ToList();
                var bestFitness = fitnessScores.Max();
                var parents = Selection(population, fitnessScores);
                var offspring = Crossover(parents);
                population = Mutation(offspring, exercises.Count);
            }

            var finalFitnessScores = population.Select(workoutPlan => FitnessFunction(workoutPlan, user, exercises)).ToList();
            return population[finalFitnessScores.IndexOf(finalFitnessScores.Max())];
        }
    }
}
