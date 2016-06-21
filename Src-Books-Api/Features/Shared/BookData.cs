using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bolt.Common.Extensions;

namespace BookWorm.BooksApi.Features.Shared
{
    public static class BookData
    {
        // category art
        private static List<BookRow> _rawData = new List<BookRow>
        {
            new BookRow
            {
                Category = "Fiction",
                Id = "24817626",
                Title = "Go Set a Watchman",
                Author = "Harper Lee",
                Image = "https://d.gr-assets.com/books/1451442088l/24817626.jpg",
                Description = @"From Harper Lee comes a landmark new novel set two decades after her beloved Pulitzer Prize-winning masterpiece, To Kill a Mockingbird. Maycomb, Alabama. Twenty-six-year-old Jean Louise Finch--""Scout""--returns home from New York City to visit her aging father, Atticus. Set against the backdrop of the civil rights tensions and political turmoil that were transforming the South, Jean Louise's homecoming turns bittersweet when she learns disturbing truths about her close-knit family, the town and the people dearest to her. Memories from her childhood flood back, and her values and assumptions are thrown into doubt. Featuring many of the iconic characters from To Kill a Mockingbird, Go Set a Watchman perfectly captures a young woman, and a world, in a painful yet necessary transition out of the illusions of the past--a journey that can be guided only by one's conscience. Written in the mid-1950s, Go Set a Watchman imparts a fuller, richer understanding and appreciation of Harper Lee. Here is an unforgettable novel of wisdom, humanity, passion, humor and effortless precision--a profoundly affecting work of art that is both wonderfully evocative of another era and relevant to our own times. It not only confirms the enduring brilliance of To Kill a Mockingbird, but also serves as its essential companion, adding depth, context and new meaning to an American classic.",
                Isbn = "0062409859"
            },
            new BookRow
            {
                Category = "Fiction",
                Id = "24941288",
                Title = "After You",
                Author = "Jojo Moyes",
                Image = "https://d.gr-assets.com/books/1425496284l/24941288.jpg",
                Description = @"I wasn't going to write a sequel to Me Before You. But for years, readers kept asking and I kept wondering what Lou did with her life. In the end the idea came, as they sometimes do, at 5:30 in the morning, leaving me sitting bolt upright in my bed and scrambling for my pen.
It has been such a pleasure revisiting Lou and her family, and the Traynors, and confronting them with a whole new set of issues. As ever, they have made me laugh, and cry. I hope readers feel the same way at meeting them—especially Lou—again. And I'm hoping that those who love Will will find plenty to enjoy.",
                Isbn = "0525426590"
            },
            new BookRow
            {
                Category = "Fiction",
                Id = "22875451",
                Title = "The Royal We ",
                Author = "Heather Cocks",
                Image = "https://d.gr-assets.com/books/1421107274l/22875451.jpg",
                Description = @"American Rebecca Porter was never one for fairy tales. Her twin sister, Lacey, has always been the romantic who fantasized about glamour and royalty, fame and fortune. Yet it's Bex who seeks adventure at Oxford and finds herself living down the hall from Prince Nicholas, Great Britain's future king. And when Bex can't resist falling for Nick, the person behind the prince, it propels her into a world she did not expect to inhabit, under a spotlight she is not prepared to face.

Dating Nick immerses Bex in ritzy society, dazzling ski trips, and dinners at Kensington Palace with him and his charming, troublesome brother, Freddie. But the relationship also comes with unimaginable baggage: hysterical tabloids, Nick's sparkling and far more suitable ex-girlfriends, and a royal family whose private life is much thornier and more tragic than anyone on the outside knows. The pressures are almost too much to bear, as Bex struggles to reconcile the man she loves with the monarch he's fated to become.

Which is how she gets into trouble.

Now, on the eve of the wedding of the century, Bex is faced with whether everything she's sacrificed for love-her career, her home, her family, maybe even herself-will have been for nothing.",
                Isbn = "1455557102"
            },
            new BookRow
            {
                Category = "Fiction",
                Id = "22822858",
                Title = "A Little Life",
                Author = "Hanya Yanagihara",
                Image = "https://d.gr-assets.com/books/1446469353l/22822858.jpg",
                Description = @"When four classmates from a small Massachusetts college move to New York to make their way, they're broke, adrift, and buoyed only by their friendship and ambition. There is kind, handsome Willem, an aspiring actor; JB, a quick-witted, sometimes cruel Brooklyn-born painter seeking entry to the art world; Malcolm, a frustrated architect at a prominent firm; and withdrawn, brilliant, enigmatic Jude, who serves as their center of gravity. Over the decades, their relationships deepen and darken, tinged by addiction, success, and pride. Yet their greatest challenge, each comes to realize, is Jude himself, by midlife a terrifyingly talented litigator yet an increasingly broken man, his mind and body scarred by an unspeakable childhood, and haunted by what he fears is a degree of trauma that he’ll not only be unable to overcome—but that will define his life forever.",
                Isbn = "0385539258"
            },

            // Mystery & Thriller
            new BookRow
            {
                Category = "Mystery & Thriller",
                Id = "23492589",
                Title = "Finders Keepers",
                Author = "Stephen King",
                Image = "https://d.gr-assets.com/books/1462023471l/22557272.jpg",
                Description = @"A masterful, intensely suspenseful novel about a reader whose obsession with a reclusive writer goes far too far—a book about the power of storytelling, starring the same trio of unlikely and winning heroes King introduced in Mr. Mercedes

“Wake up, genius.” So begins King’s instantly riveting story about a vengeful reader. The genius is John Rothstein, an iconic author who created a famous character, Jimmy Gold, but who hasn’t published a book for decades. Morris Bellamy is livid, not just because Rothstein has stopped providing books, but because the nonconformist Jimmy Gold has sold out for a career in advertising. Morris kills Rothstein and empties his safe of cash, yes, but the real treasure is a trove of notebooks containing at least one more Gold novel.",
                Isbn = "1501100076"
            },
            new BookRow
            {
                Category = "Mystery & Thriller",
                Id = "23492589",
                Title = "Career of Evil",
                Author = "Robert Galbraith",
                Image = "https://d.gr-assets.com/books/1434419930l/25735012.jpg",
                Description = @"When a mysterious package is delivered to Robin Ellacott, she is horrified to discover that it contains a woman’s severed leg.

Her boss, private detective Cormoran Strike, is less surprised but no less alarmed. There are four people from his past who he thinks could be responsible – and Strike knows that any one of them is capable of sustained and unspeakable brutality.

With the police focusing on the one suspect Strike is increasingly sure is not the perpetrator, he and Robin take matters into their own hands, and delve into the dark and twisted worlds of the other three men. But as more horrendous acts occur, time is running out for the two of them",
                Isbn = "0316349933"
            },
            new BookRow
            {
                Category = "Mystery & Thriller",
                Id = "25379213",
                Title = "Marrow",
                Author = "Tarryn Fisher",
                Image = "https://d.gr-assets.com/books/1430100052l/25379213.jpg",
                Description = @"In the Bone there is a house. In the house there is a girl. In the girl there is a darkness. Margo is not like other girls. She lives in a derelict neighborhood called the Bone, in a cursed house, with her cursed mother, who hasn’t spoken to her in over two years. She lives her days feeling invisible. It’s not until she develops a friendship with her wheelchair-bound neighbor, Judah Grant, that things begin to change. When neighborhood girl, seven-year-old Neveah Anthony, goes missing, Judah sets out to help Margo uncover what happened to her. What Margo finds changes her",
                Isbn = "0316349934"
            },
            new BookRow
            {
                Category = "Mystery & Thriller",
                Id = "24586590",
                Title = "The Nature of the Beast",
                Author = "Louise Penny",
                Image = "https://d.gr-assets.com/books/1429532809l/24586590.jpg",
                Description = @"Hardly a day goes by when nine-year-old Laurent Lepage doesn't cry wolf. From alien invasions, to walking trees, to winged beasts in the woods, to dinosaurs spotted in the village of Three Pines, his tales are so extraordinary no one can possibly believe him. But when the boy disappears, the villagers are faced with the possibility that one of his tall tales might have bee",
                Isbn = "0316349935"
            },

            //"Fantasy"

            
            new BookRow
            {
                Category = "Fantasy",
                Id = "22522808",
                Title = "Trigger Warning",
                Author = "Neil Gaiman",
                Image = "https://d.gr-assets.com/books/1415036119l/22522808.jpg",
                Description = @"Multiple award winning, #1 New York Times bestselling author Neil Gaiman returns to dazzle, captivate, haunt, and entertain with this third collection of short fiction following Smoke and Mirrors and Fragile Things--which includes a never-before published American Gods story, ""Black Dog,"" written exclusively for this volume. In this new anthology, Neil Gaiman pierces the veil of reality to reveal the enigmatic, shadowy world that lies beneath. Trigger Warning includes previously published pieces of short fiction--stories, verse, and a very special Doctor Who story",
                Isbn = "0316349936"
            },

            new BookRow
            {
                Category = "Fantasy",
                Id = "22055262",
                Title = "A Darker Shade of Magic",
                Author = "V.E. Schwab",
                Image = "https://d.gr-assets.com/books/1400322851l/22055262.jpg",
                Description = @"Kell is one of the last Antari, a rare magician who can travel between parallel worlds: hopping from Grey London — dirty, boring, lacking magic, and ruled by mad King George — to Red London — where life and magic are revered, and the Maresh Dynasty presides over a flourishing empire — to White London — ruled by whoever has murdered their way to the throne, where people fight to control magic, and the magic fights back — and back, but never Black London, because traveling to Black London is forbidden and no one speaks of it now. ",
                Isbn = "0316349937"
            },


            new BookRow
            {
                Category = "Fantasy",
                Id = "16065004",
                Title = "Shadows of Self",
                Author = "Brandon Sanderson",
                Image = "https://d.gr-assets.com/books/1435053013l/16065004.jpg",
                Description = @"Shadows of Self shows Mistborn’s society evolving as technology and magic mix, the economy grows, democracy contends with corruption, and religion becomes a growing cultural force, with four faiths competing for converts. This bustling, optimistic, but still shaky society now faces its first instance of terrorism, crimes intended to stir up labor strife and religious conflict. Wax and Wayne, assisted by the lovely, brilliant Marasi, must unravel the conspiracy before civil strife stops Scadrial’s progress in its tracks. Shadows of Self will give fans of The Alloy of Law everything they’ve been hoping",
                Isbn = "0316349938"
            },
            new BookRow
            {
                Category = "Fantasy",
                Id = "17333171",
                Title = "Magic Shifts",
                Author = "Ilona Andrews",
                Image = "https://d.gr-assets.com/books/1414091260l/17333171.jpg",
                Description = @"In the latest Kate Daniels novel from #1 New York Times bestselling author Ilona Andrews, magic is coming and going in waves in post-Shift Atlanta—and each crest leaves danger in its wake… After breaking from life with the Pack, mercenary Kate Daniels and her mate—former Beast Lord Curran Lennart—are adjusting to a very different pace. While they’re thrilled to escape all the infighting, Curran misses the constant challenges of leading the shapeshifters. So when the Pack offers him its stake in the Mercenary Guild, Curran seizes the opportunity—too bad the Guild wants nothing",
                Isbn = "0316349939"
            },
            new BookRow
            {
                Category = "Fantasy",
                Id = "24876258",
                Title = "The Aeronaut's Windlass",
                Author = "Jim Butcher",
                Image = "https://d.gr-assets.com/books/1425415066l/24876258.jpg",
                Description = @"Jim Butcher, the #1 New York Times bestselling author of The Dresden Files and the Codex Alera novels, conjures up a new series set in a fantastic world of noble families, steam-powered technology, and magic-wielding warriors… Since time immemorial, the Spires have sheltered humanity, towering for miles over the mist-shrouded surface of the world. Within their halls, aristocratic houses have ruled for generations, developing scientific marvels, fostering trade alliances, and building fleets of airships to keep the peace. ",
                Isbn = "0316349940"
            },
            new BookRow
            {
                Category = "Fantasy",
                Id = "23157777",
                Title = "Fool's Quest",
                Author = "Robin Hobbs",
                Image = "https://d.gr-assets.com/books/1420496252l/23157777.jpg",
                Description = @"Acclaimed and bestselling author Robin Hobb continues her Fitz and the Fool trilogy with this second entry, following Fool’s Assassin, ramping up the tension and the intrigue as disaster continues to strike at Fitz’s life and heart. After nearly killing his oldest friend, the Fool, and finding his daughter stolen away by those who were once targeting the Fool, FitzChivarly Farseer is out for blood. And who better to wreak havoc than a highly trained and deadly former royal assassin? Fitz might have let his skills go fallow over his years of peace",
                Isbn = "0316349941"
            },
            new BookRow
            {
                Category = "Fantasy",
                Id = "21457243",
                Title = "Vision in Silver",
                Author = "Anne Bishop",
                Image = "https://d.gr-assets.com/books/1404354570l/21457243.jpg",
                Description = @"The Others freed the  cassandra sangue  to protect the blood prophets from exploitation, not realizing their actions would have dire consequences. Now the fragile seers are in greater danger than ever before—both from their own weaknesses and from those who seek to control their divinations for wicked purposes. In desperate need of answers, Simon Wolfgard, a shape-shifter leader among the Others, has no choice but to enlist blood prophet Meg Corbyn’s help, regardless of the risks she faces by aiding him. Meg is still deep in the throes of her addiction to the euphoria she feels when she cuts and speak",
                Isbn = "0316349942"
            },

            // Romance

            new BookRow
            {
                Category = "Romance",
                Id = "23341855",
                Title = "Ride Steady",
                Author = "Kristen Ashley",
                Image = "https://d.gr-assets.com/books/1424262600l/23341855.jpg",
                Description = @"The Others freed the  cassandra sangue  to protect the blood prophets from exploitation, not realizing their actions would have dire consequences. Now the fragile seers are in greater danger than ever before—both from their own weaknesses and from those who seek to control their divinations for wicked purposes. In desperate need of answers, Simon Wolfgard, a shape-shifter leader among the Others, has no choice but to enlist blood prophet Meg Corbyn’s help, regardless of the risks she faces by aiding him. Meg is still deep in the throes of her addiction to the euphoria she feels when she cuts and speak",
                Isbn = "0316349943"
            },

            new BookRow
            {
                Category = "Romance",
                Id = "20665087",
                Title = "The Secret of Pembrooke Park",
                Author = "Julie Klassen",
                Image = "https://d.gr-assets.com/books/1413752734l/20665087.jpg",
                Description = @"Abigail Foster fears she will end up a spinster, especially as she has little dowry to improve her charms and the one man she thought might marry her--a longtime friend--has fallen for her younger, prettier sister. When financial problems force her family to sell their London home, a strange solicitor arrives with an astounding offer: the use of a distant manor house abandoned for eighteen years. The Fosters journey to imposing Pembrooke Park and are startled to find it entombed as it was abruptly left: tea cups encrusted with dry tea, moth-eaten clothes in wardrobes, a doll's house left mid-play . . . The handsome local curate welcomes them, but though he and his family seem to know something about the manor's past, the only information they offer Abigail is a warning: Beware trespassers who may be drawn by rumors that Pembrooke contains a secret room filled with treasure.",
                Isbn = "0316349944"
            },

            new BookRow
            {
                Category = "Romance",
                Id = "22717015",
                Title = "Beautiful Redemption",
                Author = "Jamie McGuire",
                Image = "https://d.gr-assets.com/books/1418155511l/22717015.jpg",
                Description = @"If A Maddox boy falls in love, he loves forever. But what if he didn't love you, first? No-nonsense Liis Lindy is an agent of the FBI. Deciding she is married only to her job, she breaks off her engagement and transfers from Chicago to the field office in San Diego. She loves her desk. She is committed to her laptop. She dreams of promotions and shaking hands with the director after cracking an impossible case. Special Agent in Charge Thomas Maddox is arrogant, unforgiving, and ruthless. He is tasked with putting away some of the world’s toughest criminals, and he is one of the best the Bureau has to offer. Though, as many lives as he’s saved, there is one that is beyond his reach. Younger brother Travis is faced with prison time for his involvement in a basement fire that killed dozens",
                Isbn = "0316349945"
            },

            // Science Fiction
            
            
            new BookRow
            {
                Category = "Science Fiction",
                Id = "20697410",
                Title = "Golden Son",
                Author = "Pierce Brown",
                Image = "https://d.gr-assets.com/books/1461354417l/20697410.jpg",
                Description = @"With shades of The Hunger Games, Ender’s Game, and Game of Thrones, debut author Pierce Brown’s genre-defying epic Red Rising hit the ground running and wasted no time becoming a sensation. Golden Son",
                Isbn = "0316349946"
            },
            new BookRow
            {
                Category = "Science Fiction",
                Id = "22826126",
                Title = "Seveneves",
                Author = "Neal Stephenson",
                Image = "https://d.gr-assets.com/books/1422566422l/22826126.jpg",
                Description = @"What would happen if the world were ending? A catastrophic event renders the earth a ticking time bomb. In a feverish race against the inevitable, nations around the globe band together to devise an a",
                Isbn = "0316349947"
            },
            new BookRow
            {
                Category = "Science Fiction",
                Id = "24388326",
                Title = "The Heart Goes Last",
                Author = "Margaret Atwood",
                Image = "https://d.gr-assets.com/books/1426167679l/24388326.jpg",
                Description = @"Living in their car, surviving on tips, Charmaine and Stan are in a desperate state. So, when they see an advertisement for Consilience, a ‘social experiment’ offering stable jobs and a home of their own, they sign up immediately. All they have to do in return for suburban paradise is give up their freedom every second month – swapping their home for a prison cell. At first, all is well. But then, unknown to each other, Stan and Charmaine develop passionate obsessions with their ‘Alternates,’ the couple that occupy their house when they are in prison. Soon the pressures of conformity, mistrust, guilt and sexual desire begin to take over",
                Isbn = "0316349948"
            },
            new BookRow
            {
                Category = "Science Fiction",
                Id = "23129410",
                Title = "Welcome to Night Vale",
                Author = "Joseph Fink",
                Image = "https://d.gr-assets.com/books/1447774088l/23129410.jpg",
                Description = @"If A Maddox boy falls in love, he loves forever. But what if he didn't love you, first? No-nonsense Liis Lindy is an agent of the FBI. Deciding she is married only to her job, she breaks off her engagement and transfers from Chicago to the field office in San Diego. She loves her desk. She is committed to her laptop. She dreams of promotions and shaking hands with the director after cracking an impossible case. Special Agent in Charge Thomas Maddox is arrogant, unforgiving, and ruthless. He is tasked with putting away some of the world’s toughest criminals, and he is one of the best the Bureau has to offer. Though, as many lives as he’s saved, there is one that is beyond his reach. Younger brother Travis is faced with prison time for his involvement in a basement fire that killed dozens",
                Isbn = "0316349949"
            },
            new BookRow
            {
                Category = "Science Fiction",
                Id = "23209924",
                Title = "The Water Knife",
                Author = "Paolo Bacigalupi",
                Image = "https://d.gr-assets.com/books/1411059576l/23209924.jpg",
                Description = @"In the American Southwest, Nevada, Arizona, and California skirmish for dwindling shares of the Colorado River. Into the fray steps Angel Velasquez, detective, leg-breaker, assassin and spy. A Las Vegas water knife, Angel ""cuts"" water for his boss, Catherine Case, ensuring that her lush, luxurious arcology developments can bloom in the desert, so the rich can stay wet, while the poor get nothing but dust. When rumors of a game-changing water source surface in drought-ravaged Phoenix, Angel is sent to investigate",
                Isbn = "0316349950"
            }
        };

        private static readonly object _lock = new object();
        private static ICollection<BookRow> _processed = null;
        private static ICollection<BookRow> _saved = null; 

        public static IEnumerable<BookRow> GetAll()
        {
            if (_processed != null) return _processed;

            lock (_lock)
            {
                if (_processed != null) return _processed;

                var rnd = new Random();

                _processed = _rawData.Select(x =>
                {
                    x.UrlFriendlyCategory = x.Category.ToSlug();
                    x.CreatedAtUtc = DateTime.UtcNow.AddDays(-rnd.Next(2000, 2016));
                    x.Price = rnd.Next(15, 60);
                    x.Popularity = rnd.Next(0, 100);
                    return x;
                }).ToList();

                return _processed;
            }
        }

        public static object SavedIds()
        {
            
        }
    }

    public class BookRow
    {
        public string UrlFriendlyCategory { get; set; }
        public string Category { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public int Popularity { get; set; }
    }
}
