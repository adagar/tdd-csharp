   M S B A M L   `   `   `  ����  TrueOrFalse     TrueOrFalse.Views.MainView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      X TXceed.Wpf.Toolkit, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      $	��300��5      .��5	      ]� .+�5
   
   o� $��30��6   $��14(�6   $	��Top=�6)   .@�5      m� $
��File��6   .@�5      m� -   5          m�Name$  NewDb��5      $	��New��6*   m� 5      -   5        $  OpenDb��5      $
��Open��6+   m� 5      -   5        $  SaveDb��5      $
��Save��6+   m� 5      -   5        $  SaveDbAs��5      $��	SaveAs...��6-   m� 5      -   5        $  	StartGame��5      $��
Start Game��6.   �� 5      m� 5      -   5        $
  Exit��5      $
��Exit��6)   5      m� 5      $
��Edit��6   .@�5      m� -   5        $	  Cut��5      $	��Cut��6(   m� 5      -   5        $
  Copy��5      $
��Copy��6)   m� 5      -	   5        $  Paste��5      $��Paste��6*   5      5      � 5   
   $��12q�6   $��45��6   $��Bottom=�6'    � ColumnDefinitions 5      �� 5      $��2* �6#   �� 5      $��* �6#   .+�5       ��  �� Orientation$ 
Horizontal=�6   .+�5!      �� -
   5         ��Name$ AddStatement��5!      $��3q�5"      $��80��6$   $	��Add��6/   �� 5#      -   5        $ RemoveStatement��5#      $��3q�62   $��80��6=   $��Remove��6H   �� 5$      -   5        $ SaveStatement��5$      $��3q�60   $��80��6;   $
��Save��6F   5%      �� 5&      $ 
Horizontal=�6   $��Center=�62   $��1��6M   .+�5'      %  Xceed.Wpf.Toolkit.IntegerUpDown  -   5          Name$ StatementNumber��5'   %   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Minimum$ 1X�5)   %      DefaultValue$ 1X�61   ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   Text$ 1��6B   $��3q�5*   %   $��60��60      Value 5(   %   �� *CurrentNumber+	 �� Mode$	 TwoWay=�5*   0   �� 5+      -   5        
 ��Name$
 TrueFalseMark��5+      $��3q�62   4  .System.Windows.Automation.AutomationProperties   AutomationId$ StatementFlag��5,      $��Center=�5/      $��Is true?��66    d� 	IsChecked 5-      �� *CurrentStatement.IsTrue+$	 TwoWay=�5/   6   50      51      �� 53   
   -   5         ��Name$ StatementText��53      $ CurrentStatement��54      ��55      �� *CurrentStatement.Text+$	 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�57      58      