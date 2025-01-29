

using System.Text;

namespace Test
{
  class Person
  {
    public string Name { get; set; }
    public int Age { get; set; }
  }
  internal class Program
  {
    private static void Main(string[] args)
    {

      Person kalle = new() { Name = "Kalle", Age = 14 };

      string result = kalle switch
      {
        { Age: < 18 } => "Not welcome on the bar",
        _ => "Welcome in",
      };

      Console.WriteLine(result);

        
        
      VideoEncoder videoEncoder = new VideoEncoder();
      Video video = new Video { Title = "Terminator" };

      VideoSubscriber.Add(videoEncoder);
      
      videoEncoder.EncodeVideo(video);
    }
  }

  public static class VideoSubscriber
  {
    public static void Add(VideoEncoder videoEncoder)
    {
      MailService mailService = new();
      MessageService messageService = new();
      SaveToDB saveToDb = new();

      videoEncoder.VideoEncoded += messageService.OnVideoEncoded;
      videoEncoder.VideoEncoded += saveToDb.OnVideoEncoded;
      videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
    }
  }
  
  public class MailService
  {
    public void OnVideoEncoded(object source, EventArgs args)
    {
      Console.WriteLine("MailService: Sending an email...");
    }
  }
  
  public class MessageService
  {
    public void OnVideoEncoded(object source, EventArgs args)
    {
      Console.WriteLine("MessageService: Sending a text message...");
    }
  }

  public class SaveToDB
  {
    public void OnVideoEncoded(object source, EventArgs args)
    {
      var data = source as VideoEncoder;
      Console.WriteLine($"Save to DB {data.videoTitle}");
    }
  }

  public class VideoEncoder
  {
    public delegate void VideoEncodedEventHandler(object source, EventArgs args);
    public event VideoEncodedEventHandler VideoEncoded;
    public string videoTitle;
    
    public void EncodeVideo(Video video)
    {
      Console.WriteLine($"Encoding video... {video.Title}");
      Thread.Sleep(3000);
      videoTitle = video.Title;
      OnVideoEncoded();
    }
    
    protected virtual void OnVideoEncoded()
    {
      if (VideoEncoded != null)
      {
        VideoEncoded(this, EventArgs.Empty);
      }
      Console.WriteLine("Video encoded");
    }
    
  }
  
  public class Video
  {
    public string Title { get; set; }
  }
}
