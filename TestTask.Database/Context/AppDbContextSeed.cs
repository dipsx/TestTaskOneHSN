using Microsoft.EntityFrameworkCore;
using TestTask.Domain;

namespace TestTask.Database.Context {
    public static class AppDbContextSeed {
        public static void Seed(this ModelBuilder builder) =>
            builder
                .SeedUsers()
                .SeedRectangles()
                ;

        private static ModelBuilder SeedUsers(this ModelBuilder builder) {
            builder.Entity<User>(entity => entity.HasData(new User {
                Id = 1,
                Email = "administrator@administrator.com",
                PasswordHash = "eR3YwtuZPO3KZjmvvpqo0OC8vcZCUpzKC9j/Us+aVOwHJWkgVX+jugi7jCeI4kCxGsB0FOP4xFZO7HIVOI5Juc78aV/ewD5auG5lt6cPaVOOGbjIDbM+0Xcfo8MkpXslgTvxzVK8EU63EWm3rJfDhsOanHANh/uQfYIoLGqwtcBcKgbzgDvaH7nGDZ4bgzEOwShp+fPKwiXZNZPuGQRsN9sEYavwDbr3fNW4AUUeVUnY66mEEFX3Lwd+n905N28YYNUG2Of+aJHQSH9x/u1hdjdwfXukB6eP0863z89x4QCSL9bq3F7CmHOAKyfxR5YSxsgKn+EWKNuBRFOFOdcbS/cumBWC0jvmwhnmLzdy7DLGGDm4ZnSXfEhzXmKMlVuP72CP+lXCvslIiiGDsjn0ZmNlP8gbw4O7Apl6X9KyPV1zJk7RlJazqRr0Yge5u7klPsocKbdLHEoOSdvR/jhLhzXKkhZunmEvvOZFYnPNnl0UX8a5G729uzdxeUghqgXhnLWFgs7nElkQ2EZVTuQv1it9uWrprpKU8YWjv+wXs7LM84EvT3oNmeBrqQUkfaSP773fwP5wULMrgIIO5NP3HzjbuKzgAOU01UMJc/Hm960gAkkBzhYjL9uolf/iJNVJ6ggEhFo+0EjvV4J52eS5fddHX5r3hQSiDK9hrb6LlHo=", // administrator
                Roles = Roles.User | Roles.Admin
            }));


            return builder;
        }

        private static ModelBuilder SeedRectangles(this ModelBuilder builder) {
            var random = new Random();
            var rectangles = Enumerable.Range(1, 200)
                .Select(index => {
                    var x1 = random.Next(0, 100);
                    var y1 = random.Next(0, 100);
                    return new Rectangle {
                        Id = index,
                        X1 = x1,
                        Y1 = y1,
                        X2 = random.Next(x1 + 1, 200),
                        Y2 = random.Next(y1 + 1, 200),
                    };
                })
                .ToArray();

            builder.Entity<Rectangle>(ent => ent.HasData(rectangles));

            return builder;
        }
    }
}