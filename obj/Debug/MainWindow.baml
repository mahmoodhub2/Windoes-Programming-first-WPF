   M S B A M L   `   `   `  ����B  >Notepad, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:NotepadNotepad  5   	       Notepad.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Notepad     5   	   -   5          � Title$  Notepad��5	   	   $	��450��6   $	��800��6&   .��5
      ]� $��1,1,1.333,0q�6   $	��419��6%   $	��Top=�62   .+�5   
   o� $	��Top=�6    J� RenderTransformOrigin$ 
0.49,4.817&�6$   @�5      m� 5      $
��File��6   .@�5      m� -   5        $	��New��5      6,   m� 5      -   5        $
��Open��5      6-   m� 5      -   5        $
��save��5      6.   m� 5      -   5        $��Save As��5      60   m� 5      -   5        $��Close��5      6.   5      m� 5      $
��Help��6   .@�5      m� -   5        $��About��5      6.   5      m� 5      $��Options��6   .@�5      m� $��	Word Wrap��6   m� 5      $
��Font��6   5      5      ]� 5   
   .+�5       �� $��Bottom=�6   ��5!      �� 5"      .R�5#      �  � ColumnDefinitions 5$      �� 5%   "   $	��100 �63   �� 5&   "   $
��Auto �63   �� 5'   "   $��* �63   �� 5(   "   $
��Auto �63   �� 5)   "   $	��100 �63   5+      5,      .@�5.      �� .��5/      �� -   5        $��position��5/       50      51      �� 52      -	   5        $��textBoxText��52   +    �� AcceptsReturn . 6>   53      54      56      