namespace FabrikamFiber.Web
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Globalization;
    using FabrikamFiber.DAL.Data;
    using FabrikamFiber.DAL.Models;

    public class FabrikamFiberDatabaseInitializer : DropCreateDatabaseIfModelChanges<FabrikamFiberWebContext>
    {
        protected override void Seed(FabrikamFiberWebContext context)
        {
            var customers = GetCustomers();
            customers.ForEach(c => context.Customers.Add(c));

            var employees = GetEmployees();
            employees.ForEach(e => context.Employees.Add(e));

            var serviceTicket = context.ServiceTickets.Add(new ServiceTicket {
                Title = "Modem keeps resetting itself",
                Description = "About two months ago, I started getting randomly disconnected. My modem would lose its ONLINE green light, then the SEND light, then the RECEIVE, and then finally the POWER light would go and the modem would reset itself. I bought the new one wondering if it my old router might be the problem (it was fairly old). However, the problem still persists",
                Status = Status.Assigned,
                EscalationLevel = 1,
                Customer = customers[0],
                CreatedBy = employees[1],
                AssignedTo = employees[0],
                Opened = DateTime.Now.AddDays(-1),
                Closed = null,
            });
            
            context.ScheduleItems.Add(new ScheduleItem
                                          {
                                              Employee = employees[0], 
                                              ServiceTicket = serviceTicket,
                                              AssignedOn = DateTime.Now.AddDays(-1),
                                              Start = DateTime.ParseExact("Mon 16 May 8:00 AM 2011", "ddd dd MMM h:mm tt yyyy", CultureInfo.InvariantCulture), 
                                              WorkHours = 1
                                          });

            context.ServiceLogEntries.Add(new ServiceLogEntry
            {
                CreatedAt = DateTime.Now.AddDays(-1),
                CreatedBy = employees[0],
                Description = "Opened ticket for customer",
                ServiceTicket = serviceTicket,
            });

            serviceTicket = context.ServiceTickets.Add(new ServiceTicket
            {
                Title = "Internet Upload speed slow from 11pm-11am",
                Description = "I'm extremely unhappy with the service I have recieved as of late from FabFiber. At night, my upload is garbage. I have the extreme 50 package and I'm only getting 1mb upload and anywhere from 1%-16% packetloss. This has been going on for a week and a half now.  I've had two techs come out here now and nobody seems to know what is going on.",
                Status = Status.Closed,
                EscalationLevel = 2,
                Customer = customers[0],
                CreatedBy = employees[0],
                AssignedTo = employees[2],
                Opened = DateTime.Now.AddDays(-1),
                Closed = DateTime.Now.AddDays(2),
            });
            
            context.ServiceLogEntries.Add(new ServiceLogEntry
            {
                CreatedAt = DateTime.Now.AddDays(-1),
                CreatedBy = employees[0],
                Description = "Opened ticket for customer",
                ServiceTicket = serviceTicket,
            });

            serviceTicket = context.ServiceTickets.Add(new ServiceTicket
            {
                Title = "FabFiber is the worst EVER!!!",
                Description = "You guys set up and no-showed two service appointments in a row. You call, they set the appointment, then reschedule it (without notifying me) and of course the guarantee no longer applies.",
                Status = Status.Open,
                EscalationLevel = 1,
                Customer = customers[1],
                CreatedBy = employees[0],
                ////AssignedTo = employees[0], It will throw an exeption to show the IntelliTrace stuff
                Opened = DateTime.Now.AddMinutes(-55),
                Closed = null,
            });

            context.ServiceLogEntries.Add(new ServiceLogEntry
            {
                CreatedAt = DateTime.Now.AddMinutes(-55),
                CreatedBy = employees[0],
                Description = "Opened ticket for customer",
                ServiceTicket = serviceTicket,
            });

            serviceTicket = context.ServiceTickets.Add(new ServiceTicket
            {
                Title = "changing channel by it self",
                Description = "TV changes channels by it self I even removed the batteries from remote and it still kept changing channels every couple of minutes what is going on this happen on only one tv out of 5 in the house?",
                Status = Status.Assigned,
                EscalationLevel = 1,
                Customer = customers[2],
                CreatedBy = employees[0],
                AssignedTo = employees[0],
                Opened = DateTime.Now.AddDays(-1),
                Closed = null,
            });

            context.ScheduleItems.Add(new ScheduleItem
            {
                Employee = employees[0],
                ServiceTicket = serviceTicket,
                AssignedOn = DateTime.Now.AddDays(-1),
                Start = DateTime.ParseExact("Mon 16 May 9:30 AM 2011", "ddd dd MMM h:mm tt yyyy", CultureInfo.InvariantCulture),
                WorkHours = 1
            });

            context.ServiceLogEntries.Add(new ServiceLogEntry
            {
                CreatedAt = DateTime.Now.AddDays(-1),
                CreatedBy = employees[0],
                Description = "Opened ticket for customer",
                ServiceTicket = serviceTicket,
            });

            serviceTicket = context.ServiceTickets.Add(new ServiceTicket
            {
                Title = "Viewing Recorded Programs",
                Description = "I would like to know if it is possible to adjust the amount of \"fast-forward\" or \"fast-rewind\" time, using the remote, while viewing a recorded program.As the remote is set, the fast-forward goes somewhat too far ahead.",
                Status = Status.Assigned,
                EscalationLevel = 2,
                Customer = customers[3],
                CreatedBy = employees[0],
                AssignedTo = employees[2],
                Opened = DateTime.Now.AddDays(-1),
                Closed = null,
            });

            context.ScheduleItems.Add(new ScheduleItem
            {
                Employee = employees[1],
                ServiceTicket = serviceTicket,
                AssignedOn = DateTime.Now.AddDays(-1),
                Start = DateTime.ParseExact("Mon 16 May 10:00 AM 2011", "ddd dd MMM h:mm tt yyyy", CultureInfo.InvariantCulture),
                WorkHours = 1
            });

            context.ServiceLogEntries.Add(new ServiceLogEntry
            {
                CreatedAt = DateTime.Now.AddDays(-1),
                CreatedBy = employees[0],
                Description = "Opened ticket for customer",
                ServiceTicket = serviceTicket,
            });

            serviceTicket = context.ServiceTickets.Add(new ServiceTicket
            {
                Title = "Issues with service",
                Description = "About a month ago I started having issues with the TV, internet and phone. The TV was pixelating and when this happened I would also lose the internet connection and phone. I called and a technician came, he said the issue was with with a lose connection with the wires outside in the apartment complex. After he came in and fixed it, the issue went away for a few weeks. Now it's back",
                Status = Status.Assigned,
                EscalationLevel = 1,
                Customer = customers[4],
                CreatedBy = employees[0],
                AssignedTo = employees[1],
                Opened = DateTime.Now.AddMinutes(-55),
                Closed = null,
            });
            
            context.ScheduleItems.Add(new ScheduleItem
            {
                Employee = employees[1],
                ServiceTicket = serviceTicket,
                AssignedOn = DateTime.Now.AddDays(-1),
                Start = DateTime.ParseExact("Mon 16 May 1:00 PM 2011", "ddd dd MMM h:mm tt yyyy", CultureInfo.InvariantCulture),
                WorkHours = 1
            });

            context.ServiceLogEntries.Add(new ServiceLogEntry
            {
                CreatedAt = DateTime.Now.AddMinutes(-55),
                CreatedBy = employees[0],
                Description = "Opened ticket for customer",
                ServiceTicket = serviceTicket,
            });

            serviceTicket = context.ServiceTickets.Add(new ServiceTicket
            {
                Title = "Poor Picture Quality",
                Description = "I just purchased a Fibrikam Fiber bundle and I am very dissatisfied with the picture quality to say the least. So far, two different service representatives have been out to look at the issue.  My picture is horribly fuzzy, grainy, blurry, and almost unwatchable.  The issue goes away when I hook the coax directly through my TV as opposed to using the provided cable box, but then I do not get as many channels.  The last service tech told me that you made some sort of change a while back and the picture quality has been poor ever since",
                Status = Status.Assigned,
                EscalationLevel = 1,
                Customer = customers[5],
                CreatedBy = employees[0],
                AssignedTo = employees[1],
                Opened = DateTime.Now.AddDays(-1),
                Closed = null,
            });
            
            context.ScheduleItems.Add(new ScheduleItem
            {
                Employee = employees[1],
                ServiceTicket = serviceTicket,
                AssignedOn = DateTime.Now.AddDays(-1),
                Start = DateTime.ParseExact("Mon 16 May 2:00 PM 2011", "ddd dd MMM h:mm tt yyyy", CultureInfo.InvariantCulture),
                WorkHours = 1
            });

            context.ServiceLogEntries.Add(new ServiceLogEntry
            {
                CreatedAt = DateTime.Now.AddDays(-1),
                CreatedBy = employees[0],
                Description = "Opened ticket for customer",
                ServiceTicket = serviceTicket,
            });

            serviceTicket = context.ServiceTickets.Add(new ServiceTicket
            {
                Title = "Channels gone!",
                Description = "I got a digital set-top box 2 years ago. Since then I get all the HD channels, basic channels, and a bunch of channels in the 200's. Since yesterday, when I turn to these stations in the 200s a gray box appears that says, \"Subscription Service.\" Is this just a temporary problem? Why can I no longer access these channels? I am still paying the same amount, what is going on?",
                Status = Status.Assigned,
                EscalationLevel = 2,
                Customer = customers[6],
                CreatedBy = employees[1],
                AssignedTo = employees[2],
                Opened = DateTime.Now.AddDays(-1),
                Closed = null,
            });

            context.ScheduleItems.Add(new ScheduleItem
            {
                Employee = employees[2],
                ServiceTicket = serviceTicket,
                AssignedOn = DateTime.Now.AddDays(-1),
                Start = DateTime.ParseExact("Mon 16 May 8:00 AM 2011", "ddd dd MMM h:mm tt yyyy", CultureInfo.InvariantCulture),
                WorkHours = 1
            });

            context.ServiceLogEntries.Add(new ServiceLogEntry
            {
                CreatedAt = DateTime.Now.AddDays(-1),
                CreatedBy = employees[0],
                Description = "Opened ticket for customer",
                ServiceTicket = serviceTicket,
            });

            serviceTicket = context.ServiceTickets.Add(new ServiceTicket
            {
                Title = "Not getting all my channels",
                Description = "I don't have access to all the channels I supposedly get.  Every channel gives me the message that I need to contact Fabrikam Fiber to subscribe, even though it is on the lineup I print out.  I went to the local office and they said it starts November 1.  Well it is November 2 and still no access",
                Status = Status.Assigned,
                EscalationLevel = 1,
                Customer = customers[7],
                CreatedBy = employees[1],
                AssignedTo = employees[2],
                Opened = DateTime.Now.AddMinutes(-55),
                Closed = null,
            });
            
            context.ScheduleItems.Add(new ScheduleItem
            {
                Employee = employees[2],
                ServiceTicket = serviceTicket,
                AssignedOn = DateTime.Now.AddDays(-1),
                Start = DateTime.ParseExact("Mon 16 May 12:00 PM 2011", "ddd dd MMM h:mm tt yyyy", CultureInfo.InvariantCulture),
                WorkHours = 1
            });

            context.ServiceLogEntries.Add(new ServiceLogEntry
            {
                CreatedAt = DateTime.Now.AddMinutes(-55),
                CreatedBy = employees[0],
                Description = "Opened ticket for customer",
                ServiceTicket = serviceTicket,
            });
        }

        private static List<Customer> GetCustomers()
        {
            var customers = new List<Customer> {
                new Customer
                {
                    FirstName = "Maria",
                    LastName = "Cameron",
                    Address = new Address
                    {
                        Street = "One Microsoft Way",
                        City = "Redmond",
                        State = "WA",
                        Zip = "98052"
                    },
                },

                new Customer
                {
                    FirstName = "Antonio",
                    LastName = "Alwan",
                    Address = new Address
                    {
                        Street = "45 Greenbelt Way",
                        City = "Redmond",
                        State = "WA",
                        Zip = "98052"
                    },
                },

                new Customer
                {
                    FirstName = "Patrick",
                    LastName = "Cook",
                    Address = new Address
                    {
                        Street = "123 Standard Street",
                        City = "Redmond",
                        State = "WA",
                        Zip = "98052"
                    },
                },

                new Customer
                {
                    FirstName = "Jane",
                    LastName = "Dow",
                    Address = new Address
                    {
                        Street = "9342 2nd Street",
                        City = "Redmond",
                        State = "WA",
                        Zip = "98052"
                    },
                },
                new Customer
                {
                    FirstName = "Michele",
                    LastName = "Martin",
                    Address = new Address
                    {
                        Street = "361 North Avenue",
                        City = "Redmond",
                        State = "WA",
                        Zip = "98052"
                    },
                },
                new Customer
                {
                    FirstName = "Dan",
                    LastName = "Bacon",
                    Address = new Address
                    {
                        Street = "45 Greenbelt Way",
                        City = "Redmond",
                        State = "WA",
                        Zip = "98052"
                    },
                },
                new Customer
                {
                    FirstName = "Johnson",
                    LastName = "Apacible",
                    Address = new Address
                    {
                        Street = "123 Standard Street",
                        City = "Redmond",
                        State = "WA",
                        Zip = "98052"
                    },
                },
                new Customer
                {
                    FirstName = "Pilar",
                    LastName = "Ackerman",
                    Address = new Address
                    {
                        Street = "9342 2nd Street",
                        City = "Redmond",
                        State = "WA",
                        Zip = "98052"
                    },
                },
                new Customer
                {
                    FirstName = "David",
                    LastName = "Alexander",
                    Address = new Address
                    {
                        Street = "361 North Avenue",
                        City = "Redmond",
                        State = "WA",
                        Zip = "98052"
                    },
                },
                new Customer
                {
                    FirstName = "Jose",
                    LastName = "Auricchio",
                    Address = new Address
                    {
                        Street = "45 Greenbelt Way",
                        City = "Redmond",
                        State = "WA",
                        Zip = "98052"
                    },
                },
                new Customer
                {
                    FirstName = "Ty",
                    LastName = "Carlson",
                    Address = new Address
                    {
                        Street = "123 Standard Street",
                        City = "Redmond",
                        State = "WA",
                        Zip = "98052"
                    },
                },
            };
            return customers;
        }

        private static List<Employee> GetEmployees()
        {
            var employees = new List<Employee> {
                new Employee
                {
                    FirstName = "Drew",
                    LastName = "Robbins",
                    Identity = "NORTHAMERICA\\drobbins",
                    Address = new Address
                    {
                        Street = "45 Greenbelt Way",
                        City = "Redmond",
                        State = "WA",
                        Zip = "98052"
                    },
                },
                new Employee
                {
                    FirstName = "Jonathan",
                    LastName = "Carter",
                    Address = new Address
                    {
                        Street = "123 Standard Street",
                        City = "Redmond",
                        State = "WA",
                        Zip = "98052"
                    },
                },
                new Employee
                {
                    FirstName = "Brian",
                    LastName = "Keller",
                    Address = new Address
                    {
                        Street = "361 North Avenue",
                        City = "Redmond",
                        State = "WA",
                        Zip = "98052"
                    },
                },
                new Employee
                {
                    FirstName = "James",
                    LastName = "Conard",
                    Address = new Address
                    {
                        Street = "9342 2nd Street",
                        City = "Redmond",
                        State = "WA",
                        Zip = "98052"
                    },
                },
            };

            return employees;
        }
    }
}