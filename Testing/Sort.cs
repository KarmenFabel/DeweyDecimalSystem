using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testing
{
    class Sort
    {
        /* Dictionary<int, bool> highlightedIndexes = new Dictionary<int, bool>();
         int operationCount;
         int operationsPerFrame;
         DateTime nextFrameTime;
         PictureBox pnlSamples;
         public bool savePicture;
         public IList PigeonholeSort(IList arrayToSort)
         {
             if (arrayToSort == null || arrayToSort.Count == 0) return arrayToSort;

             object max = null;
             object min = null;
             SetItem(arrayToSort, ref max, 0);
             SetItem(arrayToSort, ref min, 0);

             // find min and max
             for (int i = 0; i < arrayToSort.Count; i++)
             {
                 if (CompareItems(arrayToSort, i, max) > 0)
                 {
                     SetItem(arrayToSort, ref max, i);
                 }
                 else if (((IComparable)arrayToSort[i]).CompareTo(min) < 0)
                 {
                     SetItem(arrayToSort, ref min, i);
                 }
             }

             // reserve space to store array in a different form
             ArrayList[] holder = new ArrayList[(int)max - (int)min + 1];

             for (int i = 0; i < holder.Length; i++)
             {
                 holder[i] = new ArrayList();
             }

             for (int i = 0; i < arrayToSort.Count; i++)
             {
                 holder[(int)GetItem(arrayToSort, i) - (int)min].Add(GetItem(arrayToSort, i));
             }

             int k = 0;

             for (int i = 0; i < holder.Length; i++)
             {
                 if (holder[i].Count > 0)
                 {
                     for (int j = 0; j < holder[i].Count; j++)
                     {
                         SetItem(arrayToSort, k, holder[i][j]);

                         k++;
                     }
                 }
             }

             return arrayToSort;
         }
         private void SetItem(IList arrayToSort, ref object toObject, int fromIndex)
         {
             toObject = arrayToSort[fromIndex];

             if (!highlightedIndexes.ContainsKey(fromIndex))
                 highlightedIndexes.Add(fromIndex, false);

             operationCount++;
             checkForFrame();
         }
         private int CompareItems(IList arrayToSort, int index1, int index2)
         {
             if (!highlightedIndexes.ContainsKey(index1))
                 highlightedIndexes.Add(index1, false);
             if (!highlightedIndexes.ContainsKey(index2))
                 highlightedIndexes.Add(index2, false);

             operationCount++;
             checkForFrame();

             return ((IComparable)arrayToSort[index1]).CompareTo(arrayToSort[index2]);
         }
         private object GetItem(IList arrayToSort, int index)
         {
             if (!highlightedIndexes.ContainsKey(index))
                 highlightedIndexes.Add(index, false);

             operationCount++;
             checkForFrame();

             return arrayToSort[index];
         }
         private void checkForFrame()
         {
             if (operationCount >= operationsPerFrame || nextFrameTime <= DateTime.UtcNow)
             {
                 // time to draw a new frame and wait
                 DrawSamples();
                 RefreshPanel(pnlSamples);
                 if (savePicture)
                     SavePicture();

                 // prepare for next frame
                 highlightedIndexes.Clear();
                 operationCount -= operationsPerFrame; // if there were more operations than needed, don't just forget those

                 if (DateTime.UtcNow < nextFrameTime)
                 {
                     Thread.Sleep((int)((nextFrameTime - DateTime.UtcNow).TotalMilliseconds));
                 }
                 nextFrameTime = nextFrameTime.AddMilliseconds(frameMS);
             }
         }
         public void DrawSamples()
         {
             // might need to grow or shrink if size is different from original (can't change array!)
             double multiplyHeight = 1;

             // check if need to change size
             if (bmpsave.Width != pnlSamples.Width || bmpsave.Height != pnlSamples.Height)
             {
                 bmpsave = new Bitmap(pnlSamples.Width, pnlSamples.Height);
                 g = Graphics.FromImage(bmpsave);
                 pnlSamples.Image = bmpsave;
             }

             if (pnlSamples.Height != originalPanelHeight)
             {
                 multiplyHeight = (double)(pnlSamples.Height) / (double)(originalPanelHeight);
             }

             // start with white background
             g.Clear(Color.White);

             // use black sometimes
             Pen pen = new Pen(Color.Black);
             SolidBrush b = new SolidBrush(Color.Black);

             // use red sometimes
             Pen redPen = new Pen(Color.Red);
             SolidBrush redBrush = new SolidBrush(Color.Red);

             // draw a nice width based on number of elements
             int w = (pnlSamples.Width / arrayToSort.Count) - 1;

             for (int i = 0; i < this.arrayToSort.Count; i++)
             {
                 int x = (int)(((double)pnlSamples.Width / arrayToSort.Count) * i);

                 int itemHeight = (int)Math.Round(Convert.ToDouble(arrayToSort[i]) * multiplyHeight);

                 // draw highlighed versions
                 if (highlightedIndexes.ContainsKey(i))
                 {
                     if (w <= 1)
                     {
                         g.DrawLine(redPen, new Point(x, pnlSamples.Height), new Point(x, (int)(pnlSamples.Height - itemHeight)));
                     }
                     else
                     {
                         g.FillRectangle(redBrush, x, pnlSamples.Height - itemHeight, w, pnlSamples.Height);
                     }
                 }
                 else // draw normal versions
                 {
                     if (w <= 1)
                     {
                         g.DrawLine(pen, new Point(x, pnlSamples.Height), new Point(x, (int)(pnlSamples.Height - itemHeight)));
                     }
                     else
                     {
                         g.FillRectangle(b, x, pnlSamples.Height - itemHeight, w, pnlSamples.Height);
                     }
                 }
             }
         }
         private void RefreshPanel(Control pnlSort)
         {
             if (pnlSort.InvokeRequired)
             {
                 SetControlValueCallback d = new SetControlValueCallback(RefreshPanel);
                 pnlSort.Invoke(d, new object[] { pnlSort });
             }
             else
             {
                 pnlSort.Refresh();
             }
         }

         private void SavePicture()
         {
             ImageCodecInfo myImageCodecInfo = this.getEncoderInfo("image/gif");
             EncoderParameter myEncoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionLZW);
             EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 0L);
             EncoderParameters myEncoderParameters = new EncoderParameters(1);

             EncoderParameters encoderParams = new EncoderParameters(2);
             encoderParams.Param[0] = qualityParam;
             encoderParams.Param[1] = myEncoderParameter;

             if (!System.IO.Directory.Exists(outputFolder))
             {
                 System.IO.Directory.CreateDirectory(outputFolder);
             }

             string destPath = System.IO.Path.Combine(outputFolder, outputFile + imgCount + ".gif");
             //bmpsave.Save(destPath, myImageCodecInfo, encoderParams);
             bmpsave.Save(destPath, ImageFormat.Gif);
             imgCount++;
         }*/

    }
}
