   M S B A M L   `   `   `  ����I  Eappinterfacev2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:appinterfacev2appinterfacev2  5   	   '    !appinterfacev2.acceuil_sauvegarde   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:appinterfacev2     5   	     � Title$  acceuil_sauvegarde��5   	   $	��600��6$   $
��1080��61   .��5	      � .+�5
   
   �� -   5         ��Name$ 	label_nom��5
      $
��Left=�6#   $��	10,93,0,0q�6>   $	��Top=�6Q   $	��153��6i   $�� ��6u   �� 5   
   -   5         ��Name$ text_box_nom��5      $
��Left=�6(   $��179,101,0,0q�6C    �� TextWrapping$
 Wrap=�6X   $	��Top=�6l   $	��120��6�   ���	#FFD4D4D46�   �� 5   
   -   5        $ label_source��5      $�� ��6&   $
��Left=�61   $��
14,171,0,0q�6L   $	��Top=�6`   $	��153��6x   �� 5   
   -   5        $ 
txt_source��5      $
��Left=�6&   $��179,179,0,0q�6A   $
 Wrap=�6V   $	��Top=�6j   $	��120��6�   
���   ����	#FFD4D4D46�   �� 5   
   -   5        $ 	txt_cible��5      $
��Left=�6%   $��179,214,0,0q�6@   $
 Wrap=�6U   $	��Top=�6i   $	��120��6�   ���	#FFD4D4D46�   �� 5   
   -   5        $ label_cible��5      $�� ��6%   $
��Left=�60   $��
10,210,0,0q�6K   $	��Top=�6_   $	��153��6w   �� 5   
   -   5        $ label_type_sauvegarde��5      $�� ��6/   $
��Left=�6:   $��
14,281,0,0q�6U   $	��Top=�6i   $	��153��6�   �� 5   
   -   5        $ txt_sauvegarde��5      $
��Left=�6*   $��179,289,0,0q�6E   $
 Wrap=�6Z   $	��Top=�6n   $	��120��6�   ���	#FFD4D4D46�   &   System.Windows.Controls.DataGrid  5   
   -	   5          Name$ DataRead��5      $��320,29,31,99q�6%      AutoGenerateColumns$ False��6;   ��6W   �� *Items+   Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5         CellTemplate 5      �� 5      .R�5      �� $
��Play��6%   -
   5        $
��Play��5   2   6A   5      5        5       5      �� 5      .R�5      �� $��Pause��6%   -   5        $��Pause��5   3   6C   5      5!        5"       5#      �� 5$      .R�5%      �� $
��Stop��6%   -   5        $
��Stop��5%   2   6A   5&      5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 Auto 6P   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 63   ��  �� Path$	 Nom�6P     5*      $ Source��6%   $
	 Auto 6V   
 65   �� $ Sources�6V     5+      $ Target��6%   $
	 Auto 6T   
 65   �� $ Cible�6T     5,      $
 Type��6%   $
	 Auto 6R   
 63   �� $ Types�6R     5-      $ chiffrement��6%   $
	 Auto 6_   
 6:   �� $ chiffrement�6_     5.      $ prioritaire��6%   $
	 Auto 6X   
 6:   �� $
 prio�6X     5/      $ Format��6%   $
	 Auto 6R   
 65   �� $	 log�6R   51      �� 52   
   -   5         ��Name$ btn_ajouter��52      $�� ��6&   $
��Left=�61   $��135,522,0,0q�6L   $	��Top=�6a   $��64��6y   6�   �� 53   
   -   5        $ 
btn_modify��53      $�� ��6%   $
��Left=�60   $��266,522,0,0q�6K   $	��Top=�6`   $��66��6x   6�   �� 54   
   -   5        $ btn_supprimer��54      $�� ��6(   $
��Left=�63   $��402,522,0,0q�6N   $	��Top=�6c   $��20��6{   $��72��6�   6�   �� 55   
   -   5        $ btn_lire��55      $�� ��6#   $
��Left=�6.   $��559,522,0,0q�6I   $	��Top=�6^   $��20��6v   $��54��6�   6�   �� 56   
   -   5        $ label_chiffre��56      $�� ��6'   $
��Left=�62   $��
10,347,0,0q�6M   $	��Top=�6a   $	��153��6y   �� 57   
   -   5        $ txt_chiffre��57      $
��Left=�6'   $��179,351,0,0q�6B   $
 Wrap=�6W   $	��Top=�6k   $	��120��6�   ���	#FFD4D4D46�   �� 58   
   -   5        $ 
btn_retour��58      $�� ��6%   $��	28,32,0,0q�61   $��40��6D   $	��Top=�6h   $
��Left=�6�   �� 59   
   -   5         ��Name$ 
journalier��59      $
��Left=�6'   $��179,463,0,0q�6B   $	��Top=�6W   $	��120��6o   .@�5:      �� $
��json��6   6,   �� 5;      $	��xml��6   6+   5<      �� 5=   
   -   5        $ label_priorite��5=      $�� ��6(   $
��Left=�63   $��
14,405,0,0q�6N   $	��Top=�6b   $	��149��6z   �� 5>   
   -   5        $ txt_priorite��5>      $
��Left=�6(   $��179,405,0,0q�6C   $
 Wrap=�6X   $	��Top=�6l   $	��120��6�   $��26��6�   ���	#FFD4D4D46�   �� 5?   
   -   5        $ label_journalier��5?      $�� ��6*   $
��Left=�65   $��
14,461,0,0q�6P   $	��Top=�6d   $	��149��6|   5@      5A      