using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FileSpaceMonitor.Tools.MessageBox
{
    // Why can't MS Messagebox scroll instead of filling my screen? #wishitwoulddie
    // Quick and Dirty Scrollable Message Box
    public class ScrollableMessageBox
    {
        //configurables
        #region Public statics

        public static double MAX_WIDTH_FACTOR = 0.5;
        public static double MAX_HEIGHT_FACTOR = 0.6;
        public static Font FONT = SystemFonts.MessageBoxFont;

        #endregion

        //borrow show signature patterns from original MS messagebox
        #region Public show functions

        public static DialogResult Show(string text)
        {
            return ScrollableMessageBoxForm.Show(null, text, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(IWin32Window owner, string text)
        {
            return ScrollableMessageBoxForm.Show(owner, text, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string text, string caption)
        {
            return ScrollableMessageBoxForm.Show(null, text, caption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption)
        {
            return ScrollableMessageBoxForm.Show(owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
            return ScrollableMessageBoxForm.Show(null, text, caption, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
        {
            return ScrollableMessageBoxForm.Show(owner, text, caption, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return ScrollableMessageBoxForm.Show(null, text, caption, buttons, icon, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return ScrollableMessageBoxForm.Show(owner, text, caption, buttons, icon, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return ScrollableMessageBoxForm.Show(null, text, caption, buttons, icon, defaultButton);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return ScrollableMessageBoxForm.Show(owner, text, caption, buttons, icon, defaultButton);
        }

        #endregion

        //Build new form dynamically
        #region Internal form class

        class ScrollableMessageBoxForm : Form
        {
            #region Form-Designer generated code

            private System.ComponentModel.IContainer components = null;

            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            private void InitializeComponent()
            {
                this.components = new System.ComponentModel.Container();
                this.button1 = new System.Windows.Forms.Button();
                this.richTextBoxMessage = new System.Windows.Forms.RichTextBox();
                this.ScrollableMessageBoxFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
                this.panel1 = new System.Windows.Forms.Panel();
                this.pictureBoxForIcon = new System.Windows.Forms.PictureBox();
                this.button2 = new System.Windows.Forms.Button();
                this.button3 = new System.Windows.Forms.Button();
                ((System.ComponentModel.ISupportInitialize)(this.ScrollableMessageBoxFormBindingSource)).BeginInit();
                this.panel1.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForIcon)).BeginInit();
                this.SuspendLayout();
                // 
                // button1
                // 
                this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.button1.AutoSize = true;
                this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.button1.Location = new System.Drawing.Point(11, 67);
                this.button1.MinimumSize = new System.Drawing.Size(0, 24);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(75, 24);
                this.button1.TabIndex = 2;
                this.button1.Text = "OK";
                this.button1.UseVisualStyleBackColor = true;
                this.button1.Visible = false;
                // 
                // richTextBoxMessage
                // 
                this.richTextBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
                this.richTextBoxMessage.BackColor = System.Drawing.Color.White;
                this.richTextBoxMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.richTextBoxMessage.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ScrollableMessageBoxFormBindingSource, "MessageText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                this.richTextBoxMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.richTextBoxMessage.Location = new System.Drawing.Point(50, 26);
                this.richTextBoxMessage.Margin = new System.Windows.Forms.Padding(0);
                this.richTextBoxMessage.Name = "richTextBoxMessage";
                this.richTextBoxMessage.ReadOnly = true;
                this.richTextBoxMessage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
                this.richTextBoxMessage.Size = new System.Drawing.Size(200, 20);
                this.richTextBoxMessage.TabIndex = 0;
                this.richTextBoxMessage.TabStop = false;
                this.richTextBoxMessage.Text = "<Message>";
                this.richTextBoxMessage.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBoxMessage_LinkClicked);
                // 
                // panel1
                // 
                this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
                this.panel1.BackColor = System.Drawing.Color.White;
                this.panel1.Controls.Add(this.pictureBoxForIcon);
                this.panel1.Controls.Add(this.richTextBoxMessage);
                this.panel1.Location = new System.Drawing.Point(-3, -4);
                this.panel1.Name = "panel1";
                this.panel1.Size = new System.Drawing.Size(268, 59);
                this.panel1.TabIndex = 1;
                // 
                // pictureBoxForIcon
                // 
                this.pictureBoxForIcon.BackColor = System.Drawing.Color.Transparent;
                this.pictureBoxForIcon.Location = new System.Drawing.Point(15, 19);
                this.pictureBoxForIcon.Name = "pictureBoxForIcon";
                this.pictureBoxForIcon.Size = new System.Drawing.Size(32, 32);
                this.pictureBoxForIcon.TabIndex = 8;
                this.pictureBoxForIcon.TabStop = false;
                // 
                // button2
                // 
                this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.button2.Location = new System.Drawing.Point(92, 67);
                this.button2.MinimumSize = new System.Drawing.Size(0, 24);
                this.button2.Name = "button2";
                this.button2.Size = new System.Drawing.Size(75, 24);
                this.button2.TabIndex = 3;
                this.button2.Text = "OK";
                this.button2.UseVisualStyleBackColor = true;
                this.button2.Visible = false;
                // 
                // button3
                // 
                this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.button3.AutoSize = true;
                this.button3.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.button3.Location = new System.Drawing.Point(173, 67);
                this.button3.MinimumSize = new System.Drawing.Size(0, 24);
                this.button3.Name = "button3";
                this.button3.Size = new System.Drawing.Size(75, 24);
                this.button3.TabIndex = 0;
                this.button3.Text = "OK";
                this.button3.UseVisualStyleBackColor = true;
                this.button3.Visible = false;
                // 
                // ScrollableMessageBoxForm
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(260, 102);
                this.Controls.Add(this.button3);
                this.Controls.Add(this.button2);
                this.Controls.Add(this.panel1);
                this.Controls.Add(this.button1);
                this.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ScrollableMessageBoxFormBindingSource, "CaptionText", true));
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.MinimumSize = new System.Drawing.Size(276, 140);
                this.Name = "ScrollableMessageBoxForm";
                this.ShowIcon = false;
                this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                this.Text = "<Caption>";
                this.Shown += new System.EventHandler(this.ScrollableMessageBoxForm_Shown);
                ((System.ComponentModel.ISupportInitialize)(this.ScrollableMessageBoxFormBindingSource)).EndInit();
                this.panel1.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForIcon)).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();
            }

            private System.Windows.Forms.Button button1;
            private System.Windows.Forms.BindingSource ScrollableMessageBoxFormBindingSource;
            private System.Windows.Forms.RichTextBox richTextBoxMessage;
            private System.Windows.Forms.Panel panel1;
            private System.Windows.Forms.PictureBox pictureBoxForIcon;
            private System.Windows.Forms.Button button2;
            private System.Windows.Forms.Button button3;

            #endregion

            #region Private constants

            private static readonly String STANDARD_MESSAGEBOX_SEPARATOR_LINES = "---------------------------\n";
            private static readonly String STANDARD_MESSAGEBOX_SEPARATOR_SPACES = "   ";
            private enum ButtonId { OK = 0, CANCEL, YES, NO, ABORT, RETRY, IGNORE };
            private static readonly String[] BUTTON_TEXTS = { "OK", "Cancel", "&Yes", "&No", "&Abort", "&Retry", "&Ignore" };
            // TODO: Hotkeys?

            #endregion

            #region Private members

            private MessageBoxDefaultButton _defaultButton;
            private int _visibleButtonsCount;

            #endregion

            #region Private constructor

            private ScrollableMessageBoxForm()
            {
                InitializeComponent();

                this.KeyPreview = true;
                this.KeyUp += ScrollableMessageBoxForm_KeyUp;
            }

            #endregion

            #region Private helper functions

            private static string[] GetStringRows(string message)
            {
                if (string.IsNullOrEmpty(message)) return null;

                var messageRows = message.Split(new char[] { '\n' }, StringSplitOptions.None);
                return messageRows;
            }

            private string GetButtonText(ButtonId buttonId)
            {
                var buttonTextArrayIndex = Convert.ToInt32(buttonId);
                return BUTTON_TEXTS[buttonTextArrayIndex];
            }

            private static double GetCorrectedWorkingAreaFactor(double workingAreaFactor)
            {
                const double minFactor = 0.2;
                const double maxFactor = 1.0;

                if (workingAreaFactor < minFactor) return minFactor;
                if (workingAreaFactor > maxFactor) return maxFactor;

                return workingAreaFactor;
            }

            private static void SetDialogStartPosition(ScrollableMessageBoxForm scrollableMessageBoxForm, IWin32Window owner)
            {
                //If no owner given: Center on current screen
                if (owner == null)
                {
                    var screen = Screen.FromPoint(Cursor.Position);
                    scrollableMessageBoxForm.StartPosition = FormStartPosition.Manual;
                    scrollableMessageBoxForm.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - scrollableMessageBoxForm.Width / 2;
                    scrollableMessageBoxForm.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - scrollableMessageBoxForm.Height / 2;
                }
            }

            private static void SetDialogSizes(ScrollableMessageBoxForm scrollableMessageBoxForm, string text, string caption)
            {
                //First set the bounds for the maximum dialog size
                scrollableMessageBoxForm.MaximumSize = new Size(Convert.ToInt32(SystemInformation.WorkingArea.Width * ScrollableMessageBoxForm.GetCorrectedWorkingAreaFactor(MAX_WIDTH_FACTOR)),
                                                              Convert.ToInt32(SystemInformation.WorkingArea.Height * ScrollableMessageBoxForm.GetCorrectedWorkingAreaFactor(MAX_HEIGHT_FACTOR)));

                //Get rows. Exit if there are no rows to render...
                var stringRows = GetStringRows(text);
                if (stringRows == null) return;

                //Calculate whole text height
                var textHeight = TextRenderer.MeasureText(text, FONT).Height;

                //Calculate width for longest text line
                const int scrollbarWidthOffset = 15;
                var longestTextRowWidth = stringRows.Max(textForRow => TextRenderer.MeasureText(textForRow, FONT).Width);
                var captionWidth = TextRenderer.MeasureText(caption, SystemFonts.CaptionFont).Width;
                var textWidth = Math.Max(longestTextRowWidth + scrollbarWidthOffset, captionWidth);

                //Calculate margins
                var marginWidth = scrollableMessageBoxForm.Width - scrollableMessageBoxForm.richTextBoxMessage.Width;
                var marginHeight = scrollableMessageBoxForm.Height - scrollableMessageBoxForm.richTextBoxMessage.Height;

                //Set calculated dialog size (if the calculated values exceed the maximums, they were cut by windows forms automatically)
                scrollableMessageBoxForm.Size = new Size(textWidth + marginWidth,
                                                       textHeight + marginHeight);
            }

            private static void SetDialogIcon(ScrollableMessageBoxForm scrollableMessageBoxForm, MessageBoxIcon icon)
            {
                switch (icon)
                {
                    case MessageBoxIcon.Information:
                        scrollableMessageBoxForm.pictureBoxForIcon.Image = SystemIcons.Information.ToBitmap();
                        break;
                    case MessageBoxIcon.Warning:
                        scrollableMessageBoxForm.pictureBoxForIcon.Image = SystemIcons.Warning.ToBitmap();
                        break;
                    case MessageBoxIcon.Error:
                        scrollableMessageBoxForm.pictureBoxForIcon.Image = SystemIcons.Error.ToBitmap();
                        break;
                    case MessageBoxIcon.Question:
                        scrollableMessageBoxForm.pictureBoxForIcon.Image = SystemIcons.Question.ToBitmap();
                        break;
                    default:
                        //When no icon is used: Correct placement and width of rich text box.
                        scrollableMessageBoxForm.pictureBoxForIcon.Visible = false;
                        scrollableMessageBoxForm.richTextBoxMessage.Left -= scrollableMessageBoxForm.pictureBoxForIcon.Width;
                        scrollableMessageBoxForm.richTextBoxMessage.Width += scrollableMessageBoxForm.pictureBoxForIcon.Width;
                        break;
                }
            }

            private static void SetDialogButtons(ScrollableMessageBoxForm scrollableMessageBoxForm, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton)
            {
                //Set the buttons visibilities and texts
                switch (buttons)
                {
                    case MessageBoxButtons.AbortRetryIgnore:
                        scrollableMessageBoxForm._visibleButtonsCount = 3;

                        scrollableMessageBoxForm.button1.Visible = true;
                        scrollableMessageBoxForm.button1.Text = scrollableMessageBoxForm.GetButtonText(ButtonId.ABORT);
                        scrollableMessageBoxForm.button1.DialogResult = DialogResult.Abort;

                        scrollableMessageBoxForm.button2.Visible = true;
                        scrollableMessageBoxForm.button2.Text = scrollableMessageBoxForm.GetButtonText(ButtonId.RETRY);
                        scrollableMessageBoxForm.button2.DialogResult = DialogResult.Retry;

                        scrollableMessageBoxForm.button3.Visible = true;
                        scrollableMessageBoxForm.button3.Text = scrollableMessageBoxForm.GetButtonText(ButtonId.IGNORE);
                        scrollableMessageBoxForm.button3.DialogResult = DialogResult.Ignore;

                        scrollableMessageBoxForm.ControlBox = false;
                        break;

                    case MessageBoxButtons.OKCancel:
                        scrollableMessageBoxForm._visibleButtonsCount = 2;

                        scrollableMessageBoxForm.button2.Visible = true;
                        scrollableMessageBoxForm.button2.Text = scrollableMessageBoxForm.GetButtonText(ButtonId.OK);
                        scrollableMessageBoxForm.button2.DialogResult = DialogResult.OK;

                        scrollableMessageBoxForm.button3.Visible = true;
                        scrollableMessageBoxForm.button3.Text = scrollableMessageBoxForm.GetButtonText(ButtonId.CANCEL);
                        scrollableMessageBoxForm.button3.DialogResult = DialogResult.Cancel;

                        scrollableMessageBoxForm.CancelButton = scrollableMessageBoxForm.button3;
                        break;

                    case MessageBoxButtons.RetryCancel:
                        scrollableMessageBoxForm._visibleButtonsCount = 2;

                        scrollableMessageBoxForm.button2.Visible = true;
                        scrollableMessageBoxForm.button2.Text = scrollableMessageBoxForm.GetButtonText(ButtonId.RETRY);
                        scrollableMessageBoxForm.button2.DialogResult = DialogResult.Retry;

                        scrollableMessageBoxForm.button3.Visible = true;
                        scrollableMessageBoxForm.button3.Text = scrollableMessageBoxForm.GetButtonText(ButtonId.CANCEL);
                        scrollableMessageBoxForm.button3.DialogResult = DialogResult.Cancel;

                        scrollableMessageBoxForm.CancelButton = scrollableMessageBoxForm.button3;
                        break;

                    case MessageBoxButtons.YesNo:
                        scrollableMessageBoxForm._visibleButtonsCount = 2;

                        scrollableMessageBoxForm.button2.Visible = true;
                        scrollableMessageBoxForm.button2.Text = scrollableMessageBoxForm.GetButtonText(ButtonId.YES);
                        scrollableMessageBoxForm.button2.DialogResult = DialogResult.Yes;

                        scrollableMessageBoxForm.button3.Visible = true;
                        scrollableMessageBoxForm.button3.Text = scrollableMessageBoxForm.GetButtonText(ButtonId.NO);
                        scrollableMessageBoxForm.button3.DialogResult = DialogResult.No;

                        scrollableMessageBoxForm.ControlBox = false;
                        break;

                    case MessageBoxButtons.YesNoCancel:
                        scrollableMessageBoxForm._visibleButtonsCount = 3;

                        scrollableMessageBoxForm.button1.Visible = true;
                        scrollableMessageBoxForm.button1.Text = scrollableMessageBoxForm.GetButtonText(ButtonId.YES);
                        scrollableMessageBoxForm.button1.DialogResult = DialogResult.Yes;

                        scrollableMessageBoxForm.button2.Visible = true;
                        scrollableMessageBoxForm.button2.Text = scrollableMessageBoxForm.GetButtonText(ButtonId.NO);
                        scrollableMessageBoxForm.button2.DialogResult = DialogResult.No;

                        scrollableMessageBoxForm.button3.Visible = true;
                        scrollableMessageBoxForm.button3.Text = scrollableMessageBoxForm.GetButtonText(ButtonId.CANCEL);
                        scrollableMessageBoxForm.button3.DialogResult = DialogResult.Cancel;

                        scrollableMessageBoxForm.CancelButton = scrollableMessageBoxForm.button3;
                        break;

                    case MessageBoxButtons.OK:
                    default:
                        scrollableMessageBoxForm._visibleButtonsCount = 1;
                        scrollableMessageBoxForm.button3.Visible = true;
                        scrollableMessageBoxForm.button3.Text = scrollableMessageBoxForm.GetButtonText(ButtonId.OK);
                        scrollableMessageBoxForm.button3.DialogResult = DialogResult.OK;

                        scrollableMessageBoxForm.CancelButton = scrollableMessageBoxForm.button3;
                        break;
                }

                //Set default button (used in ScrollableMessageBoxForm_Shown)
                scrollableMessageBoxForm._defaultButton = defaultButton;
            }

            #endregion

            #region Private event handlers

            private void ScrollableMessageBoxForm_Shown(object sender, EventArgs e)
            {
                int buttonIndexToFocus = 1;
                Button buttonToFocus;

                //Set the default button...
                switch (this._defaultButton)
                {
                    default:
                        buttonIndexToFocus = 1;
                        break;
                    case MessageBoxDefaultButton.Button2:
                        buttonIndexToFocus = 2;
                        break;
                    case MessageBoxDefaultButton.Button3:
                        buttonIndexToFocus = 3;
                        break;
                }

                if (buttonIndexToFocus > _visibleButtonsCount) buttonIndexToFocus = _visibleButtonsCount;

                if (buttonIndexToFocus == 3)
                {
                    buttonToFocus = button3;
                }
                else if (buttonIndexToFocus == 2)
                {
                    buttonToFocus = button2;
                }
                else
                {
                    buttonToFocus = button1;
                }

                buttonToFocus.Focus();
            }

            private void richTextBoxMessage_LinkClicked(object sender, LinkClickedEventArgs e)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Process.Start(e.LinkText);
                }
                catch (Exception)
                {
                    //TODO: Let the caller of ScrollableMessageBoxForm decide what to do with this exception...
                    throw;
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }

            }

            void ScrollableMessageBoxForm_KeyUp(object sender, KeyEventArgs e)
            {
                //Handle standard key strikes for clipboard copy: "Ctrl + C" and "Ctrl + Insert"
                if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.Insert))
                {
                    var buttonsTextLine = (button1.Visible ? button1.Text + STANDARD_MESSAGEBOX_SEPARATOR_SPACES : string.Empty)
                                        + (button2.Visible ? button2.Text + STANDARD_MESSAGEBOX_SEPARATOR_SPACES : string.Empty)
                                        + (button3.Visible ? button3.Text + STANDARD_MESSAGEBOX_SEPARATOR_SPACES : string.Empty);

                    //Build same clipboard text like the standard .Net MessageBox
                    var textForClipboard = STANDARD_MESSAGEBOX_SEPARATOR_LINES
                                         + Text + Environment.NewLine
                                         + STANDARD_MESSAGEBOX_SEPARATOR_LINES
                                         + richTextBoxMessage.Text + Environment.NewLine
                                         + STANDARD_MESSAGEBOX_SEPARATOR_LINES
                                         + buttonsTextLine.Replace("&", string.Empty) + Environment.NewLine
                                         + STANDARD_MESSAGEBOX_SEPARATOR_LINES;

                    //Set text in clipboard
                    Clipboard.SetText(textForClipboard);
                }
            }

            #endregion

            #region Public Properties for Binding

            // Needs to remain public 
            public string CaptionText { get; set; }
            public string MessageText { get; set; }

            #endregion

            #region Public show function

            public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
            {
                var messageBoxForm = new ScrollableMessageBoxForm();
                messageBoxForm.ShowInTaskbar = false;

                //Bind the caption and the message text
                messageBoxForm.CaptionText = caption;
                messageBoxForm.MessageText = text;
                messageBoxForm.ScrollableMessageBoxFormBindingSource.DataSource = messageBoxForm;

                //Set the buttons visibilities and texts. Also set a default button.
                SetDialogButtons(messageBoxForm, buttons, defaultButton);

                //Set the dialogs icon. When no icon is used: Correct placement and width of rich text box.
                SetDialogIcon(messageBoxForm, icon);

                //Set the font for all controls
                messageBoxForm.Font = FONT;
                messageBoxForm.richTextBoxMessage.Font = FONT;

                //Calculate the dialogs start size (Try to auto-size width to show longest text row). Also set the maximum dialog size. 
                SetDialogSizes(messageBoxForm, text, caption);

                //Set the dialogs start position when given. Otherwise center the dialog on the current screen.
                SetDialogStartPosition(messageBoxForm, owner);

                //Show the dialog
                return messageBoxForm.ShowDialog(owner);
            }

            #endregion
        } //class ScrollableMessageBoxForm

        #endregion
    }
}
