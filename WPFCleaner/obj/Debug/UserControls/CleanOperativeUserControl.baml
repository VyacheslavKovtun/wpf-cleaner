   M S B A M L   `   `   `  ����E  AWPFCleaner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WPFCleaner.UserControlsWPFCleaner.UserControls  5      7    1WPFCleaner.UserControls.CleanOperativeUserControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:WPFCleaner.UserControls     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5	      $��Regular"�5
      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .��5      � ���	#FF05191F � RowDefinitions 5   
   �� 5      $	��10* �6   �� 5      .+�5   
   � $��0��6   .+�5      �� $��Center=�6   
�������$��20(�6D   .��6R   Current processes6e   �� 5      -   5         ��Name$ ProcessesLB��5      $��	3 35 3 10q�6+   $
��Auto=�6�   ��6>   �� *	Processes+ �� SelectedItem 6`   �� *SelectedProcess+��5      �� 5      .R�5      ��  ��Name$ CBorder��6!    �� Padding$ 8q�62   $��0 0 0 1q�6>     MaterialDesignDivider#���  6X   ._�5      � $
��1020��6#    � ColumnDefinitions 5   "   �� 5    &   $��3* �67   �� 5!   &   $��2* �67   �� 5"   &   $��2* �67   �� 5#   &   $��4* �67   �� 5$   &   $��3* �67   .+�5(   "   �� $��0��6,   $��5q�6<   $��15(�6d   
���������6G   �� *ProcessName+6r   �� 5)   "   $��1��6,   $��5q�6<   $��15(�6a   
���������6G   �� *
Priority+6o   �� 5*   "   $��2��6,   $��5q�6<   $��15(�6d   
���������6G   �� *HandleCount+6r   �� 5+   "   $��3��6,   $��5q�6<   $��15(�6b   
���������6G   �� *	StartTime+6p   �� 5,   "   $��4��6,   $��5q�6<   $��15(�6c   
���������6G   �� *
MemorySize+6q   5-      5.       �� Triggers 50      �� 51      	 �� Value$
	 True��6P   
 �� Binding
 6*   �� *IsSelectedProcess+.a�52   "   ��  �� 
TargetName$ CBorder��6)     MaterialDesignSelection �� Value# �  6T    �� Property � ��53      55      57      58      � 5:   
   $��1��6    5;      �� 5<      �� 5=      .+�5@      �� -   5         ��Name$ CloseSelProcessBtn��5@      $��0��61   $��17(�6A   ��6O   �� *CloseProcessCommand+��6w   �� *SelectedProcess+.��6�   Close selected process6�   �� 5A      -   5        $ AutoCloseProcessesBtn��5A      $��1��64   $��17(�6D   .��6v   
Auto close6�   5B      5C      5D      