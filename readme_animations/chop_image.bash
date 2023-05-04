#!/bin/bash

: << 'COMMENT'
Bash script with a function to generate animations in GIF format using
ImageMagick; it takes as an input a long image with n sequential frames, the
script crops each frame and generates the animation.

The input image should have consecutive frames along the longitudinal axis
(x-axis), the size of the image should be given by the formula (n*size)xsize.

Small modifications on the code can be done to crop vertilcal (y-axis) images
changing the gravity options (North, South) and the order of the chop options
in convert command.
COMMENT

size=32			# SIZE OF SINGLE FRAME IN INPUT IMAGE (IN PIXELS)
n=11			# NUMBER OF FRAMES IN INPUT IMAGE
in_name="Idle.png"	# INPUT IMAGE NAME

# GIF FUNCTION
gif_fun (){
  # LOOP OVER THE NUMBER OF FRAMES n
  for i in $( seq 1 $n);do
    # OUTPUT FILE INDEX
    index=$(printf %02d $i)
    # CHOP RIGHT AND LEFT SIDE OF ith FRAME
    convert $in_name -gravity East -chop $(( (n-i)*size))x0 image_$index.png
    convert image_$index.png -gravity West -chop $(( (i-1)*size))x0 image_$index.png
  done
  # OUTPUT ANIMATION NAME, 'gif' EXTENSION REPLACED BY 'png'
  ou_name=${in_name//png/gif}
  rm $ou_name
  # MAKE .gif ANIMATION USING SEQUENCE OF CHOPPED IMAGE
  convert -delay 4 -loop 0 -dispose previous image_*.png $ou_name
  rm image_*
}

n=12
in_name="Run.png"
gif_fun

n=17	
in_name="Bananas.png"
gif_fun

n=17
in_name="Strawberry.png"
gif_fun

n=7
in_name="Hit.png"
gif_fun
